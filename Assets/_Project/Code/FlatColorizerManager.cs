using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class FlatColorizerManager
{
    private static Material CreateMaterial()
    {
        // Create the folder path
        string folderPath = "Assets/Resources/FlatColorizer/Material";

        // Check if the folder exists, and create it if it doesn't
        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            AssetDatabase.Refresh();
        }

        // Create a new instance of the material
        Material newMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));

        // Save the material to a file
        string materialPath = $"{folderPath}/SharedMat.mat";
        AssetDatabase.CreateAsset(newMaterial, materialPath);

        // Refresh the asset database to ensure the new material appears in the project view
        AssetDatabase.Refresh();
        return newMaterial;
    }

    public static Material GetSharedMaterial()
    {
        Material sharedMat = Resources.Load<Material>("FlatColorizer/Material/SharedMat");
        if (sharedMat == null)
            sharedMat = CreateMaterial();

        return sharedMat;
    }
}
