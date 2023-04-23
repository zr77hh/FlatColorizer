using UnityEngine;

public class FlatColorizer : MonoBehaviour
{
    [SerializeField] private Color[] _color;

    private MeshRenderer _renderer;
    private MeshFilter _meshFilter;

    private void AddMaterial()
    {
        if (_renderer == null)
            _renderer = GetComponent<MeshRenderer>();


        Material sharedMat = FlatColorizerManager.GetSharedMaterial();

        if (_renderer.sharedMaterial != sharedMat)
            _renderer.sharedMaterials = new Material[] { sharedMat };
    }

    private void AddMesh()
    {
        if (_meshFilter == null)
            _meshFilter = GetComponent<MeshFilter>();

        Mesh flatColoredMesh = FlatColorizerManager.GetFlatColorizedMesh(_meshFilter.sharedMesh);
        if (_meshFilter.sharedMesh != flatColoredMesh)
        {
            _meshFilter.sharedMesh = flatColoredMesh;
            for (int i = 0; i < flatColoredMesh.uv.Length; i++)
            {
                Debug.Log(flatColoredMesh.uv[i]);
            }
        }
    }

    public void FlatColorize()
    {
        AddMaterial();
        AddMesh();
    }
}
