using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TerrainEditor terrainEditor;
    [SerializeField] private TMPro.TMP_InputField seedInput;
    [SerializeField] private TMPro.TMP_InputField detailInput;
    [SerializeField] private TMPro.TMP_InputField heightCorrectionInput;
    [SerializeField] private TMPro.TMP_InputField seaHeightInput;
    [SerializeField] private GameObject sea;

    public void Generate()
    {
        terrainEditor.UpdateTerrain();
        sea.transform.position = new Vector3(sea.transform.position.x, float.Parse(seaHeightInput.text), sea.transform.position.z);
    }

    public void UpdateSeed()
    {
        if (int.TryParse(seedInput.text, out int seed))
            terrainEditor.seed = seed;
    }

    public void UpdateDetail()
    {
        if (float.TryParse(detailInput.text, out float detail))
            terrainEditor.detail = detail;
    }

    public void UpdateHeightCorrection()
    {
        if (float.TryParse(heightCorrectionInput.text, out float heightCorrection))
            terrainEditor.heightCorrection = heightCorrection;
    }
}
