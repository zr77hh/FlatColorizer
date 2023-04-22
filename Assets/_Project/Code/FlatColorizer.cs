using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class FlatColorizer : MonoBehaviour
{
    [SerializeField] private Color[] _color;

    private MeshRenderer _renderer;

    private void AddMaterial()
    {
        Material sharedMat = FlatColorizerManager.GetSharedMaterial();

        if (_renderer == null)
            _renderer = GetComponent<MeshRenderer>();

        if (_renderer.sharedMaterial != sharedMat)
            _renderer.sharedMaterial = sharedMat;
    }

   

    public void FlatColorize()
    {
        AddMaterial();

    }
}
