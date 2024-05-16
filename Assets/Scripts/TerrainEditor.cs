using UnityEngine;

public class TerrainEditor : MonoBehaviour
{
    public TerrainData terrainData;
    public Terrain terrain;
    public int seed = 0;
    public float detail = 150;
    public float heightCorrection = -0.05f;
    public int treeCount = 50;
    public float minX = 0;
    public float maxX = 100;
    public float minZ = 0;
    public float maxZ = 100;

    private float[,] matrix;

    private void Start()
    {
        matrix = new float[513, 513];
        HeightGenerator();

        terrainData.SetHeights(0, 0, matrix);

        terrain.GetComponent<TerrainPaint>().PaintTerrain();

        //GenerateTrees();
    }

    internal void UpdateTerrain()
    {
        HeightGenerator();
        terrainData.SetHeights(0, 0, matrix);
        terrain.GetComponent<TerrainPaint>().PaintTerrain();
    }

    private void HeightGenerator()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = Mathf.PerlinNoise((float)(i + seed) / detail, (float)(j + seed) / detail) + heightCorrection;
            }
        }
    }

    private void GenerateTrees()
    {
        for (int i = 0; i < treeCount; i++)
        {
            TreeInstance tree = new TreeInstance();
            tree.prototypeIndex = 0;
            Vector3 pos = new Vector3(Random.Range(minX / terrainData.size.x, maxX / terrainData.size.x), 0, Random.Range(minZ / terrainData.size.z, maxZ / terrainData.size.z));
            tree.position = pos;
            terrain.AddTreeInstance(tree);
        }

        for (int i = 0; i < treeCount; i++)
        {
            
        }
    }
}
