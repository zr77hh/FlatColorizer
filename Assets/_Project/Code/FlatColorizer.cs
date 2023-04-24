using UnityEngine;

public class FlatColorizer : MonoBehaviour
{
#if UNITY_EDITOR

    public Color[] _color;

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

        if (_meshFilter.sharedMesh == null)
        {
            Debug.LogError("there is no mesh to flat colorize");
            return;
        }

        Mesh flatColoredMesh = FlatColorizerManager.GetFlatColorizedMesh(_meshFilter.sharedMesh);
        if (_meshFilter.sharedMesh != flatColoredMesh)
        {
            _meshFilter.sharedMesh = flatColoredMesh;
        }
    }

    public void FlatColorize()
    {
        AddMaterial();
        AddMesh();
        Debug.Log("flat");
    }


#endif
}
