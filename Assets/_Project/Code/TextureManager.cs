using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureManager
{
    private static Texture2D _texture
    {
        get
        {
            return FlatColorizerManager.GetTexture();
        }
    }

}
