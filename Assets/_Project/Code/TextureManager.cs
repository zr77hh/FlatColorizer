using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureManager
{
    private static Texture2D _texture;

    private static void FindeTexture()
    {
        if (_texture == null)
            _texture = FlatColorizerManager.GetTexture();
    }

    private static int[] GetAllOccupiedPixelsIndexes()
    {
        List<int> occupiedPixelsIndexes = new List<int>();

        FlatColoredMeshData[] allMeshesData = FlatColorizerManager.GetAllMeshesData();
        for (int i = 0; i < allMeshesData.Length; i++)
        {
            for (int e = 0; e < allMeshesData[i].occupiedPixelsIndexes.Length; e++)
            {
                occupiedPixelsIndexes.Add(allMeshesData[i].occupiedPixelsIndexes[e]);
            }
        }

        return occupiedPixelsIndexes.ToArray();
    }

    private static Vector2Int IndexToPixelCoordinate(int index)
    {
        FindeTexture();

        int x = index % _texture.width;
        int y = index / _texture.width;
        return new Vector2Int(x, y);
    }

    private static int PixelCoordinateToIndex(int x, int y)
    {
        FindeTexture();

        return y * _texture.width + x;
    }


    private static int[] GetUnoccupiedPixelsIndexes(int count)
    {
        FindeTexture();

        // get all pixels indexes
        List<int> availablePixels = new List<int>();
        for (int i = 0; i < _texture.width * _texture.height; i++)
        {
            availablePixels.Add(i);
        }

        //remove occupied pixels indexes
        int[] occupiedPixels = GetAllOccupiedPixelsIndexes();
        for (int i = 0; i < occupiedPixels.Length; i++)
        {
            availablePixels.Remove(occupiedPixels[i]);
        }

        // return unoccupied pixels indexes 
        int[] unoccupiedPixelsIndexes = new int[count];
        for (int i = 0; i < count; i++)
        {
            unoccupiedPixelsIndexes[i] = availablePixels[i];
        }

        return unoccupiedPixelsIndexes;
    }

    public static void AddMeshData(FlatColoredMeshData meshData)
    {
        FindeTexture();

        int[] unoccupiedPixelsIndexes = GetUnoccupiedPixelsIndexes(meshData.colorGroups.Count);
        Vector2[] positions = new Vector2[meshData.colorGroups.Count];
        for (int i = 0; i < meshData.colorGroups.Count; i++)
        {
            Vector2Int pixelCoordinate = IndexToPixelCoordinate(unoccupiedPixelsIndexes[i]);

            positions[i] = new Vector2((float)pixelCoordinate.x / _texture.width, (float)pixelCoordinate.y / _texture.height);

            _texture.SetPixel(pixelCoordinate.x, pixelCoordinate.y, meshData.colorGroups[i].color);
        }
        _texture.Apply();


        meshData.SetOccupiedPixelsIndexes(unoccupiedPixelsIndexes);
        meshData.SetColorGroupsPositions(positions);
    }

    public static void SetPixelColor(int pixelIndex, Color color)
    {
        FindeTexture();

        Vector2Int pixelCoordinate = IndexToPixelCoordinate(pixelIndex);

        _texture.SetPixel(pixelCoordinate.x, pixelCoordinate.y, color);
        _texture.Apply();
    }
}
