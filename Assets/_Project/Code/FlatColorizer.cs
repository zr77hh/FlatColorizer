using UnityEngine;

public class FlatColorizer : MonoBehaviour
{
#if UNITY_EDITOR

    public Color[] _color = new Color[0];

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
            _meshFilter.sharedMesh = flatColoredMesh;
    }

    private void UpdateColor()
    {
        if (_meshFilter.sharedMesh == null)
            return;

        FlatColoredMeshData meshData = FlatColorizerManager.GetMeshData(_meshFilter.sharedMesh);
        if (_color.Length != meshData.colorGroups.Count)
        {
            _color = new Color[meshData.colorGroups.Count];
            for (int i = 0; i < _color.Length; i++)
            {
                _color[i] = meshData.colorGroups[i].color;
            }
        }
    }

    public void FlatColorize()
    {
        AddMaterial();
        AddMesh();
        UpdateColor();
    }


#endif
}
