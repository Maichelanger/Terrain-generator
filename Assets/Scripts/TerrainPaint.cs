using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPaint : MonoBehaviour
{
    [System.Serializable]

    public class HeightTexture
    {
        public int textureIndex;
        public int startingHeight;
    }

    public HeightTexture[] heightTextures;

    public void PaintTerrain()
    {
        TerrainData terrainData = Terrain.activeTerrain.terrainData;
        float[,,] heightMap = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];

        for (int y = 0; y < terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                float localHeight = terrainData.GetHeight(y, x);
                float[] splat = new float[heightTextures.Length];

                for (int i = 0; i < (heightTextures.Length - 1); i++)
                {
                    if (localHeight >= heightTextures[i].startingHeight && localHeight < heightTextures[i+1].startingHeight)
                    {
                        splat[i] = 1;
                    }
                }

                if (localHeight >= heightTextures[heightTextures.Length - 1].startingHeight)
                {
                    splat[heightTextures.Length - 1] = 1;
                }

                for (int i = 0; i < heightTextures.Length; i++)
                {
                    heightMap[x, y, i] = splat[i];
                }
            }
        }

        terrainData.SetAlphamaps(0, 0, heightMap);
    }
}
