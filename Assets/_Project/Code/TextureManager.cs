using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureManager
{
    private static Texture2D _texture;


    public static void AddMeshData(FlatColoredMeshData meshData)
    {
        if (_texture == null)
            _texture = FlatColorizerManager.GetTexture();

        Vector2[] positions = new Vector2[meshData.colorGroups.Count];
        for (int i = 0; i < meshData.colorGroups.Count; i++)
        {
            _texture.SetPixel(i, 0, meshData.colorGroups[i].color);
            positions[i] = new Vector2((float)i / _texture.width, 0);
       
            Debug.Log(positions[i].ToString());
        }
        _texture.Apply();
        meshData.SetColorGroupsPositions(positions);

    }

    public static void SetMeshColor(int colorIndex, Color color)
    {
        if (_texture == null)
            _texture = FlatColorizerManager.GetTexture();

        _texture.SetPixel(colorIndex, 0, color);
        _texture.Apply();
    }
}
