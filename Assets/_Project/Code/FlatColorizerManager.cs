using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class FlatColorizerManager
{
    private const string FLAT_COLORED = "FlatColored_";


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

        newMaterial.mainTexture = GetTexture();

        // Save the material to a file
        string materialPath = $"{folderPath}/SharedMat.mat";
        AssetDatabase.CreateAsset(newMaterial, materialPath);

        // Refresh the asset database to ensure the new material appears in the project view
        AssetDatabase.Refresh();

        Debug.Log("new material created");
        return newMaterial;
    }

    private static Texture2D CreateTexture()
    {
        // Create the folder path
        string folderPath = "Assets/Resources/FlatColorizer/Texture";

        // Check if the folder exists, and create it if it doesn't
        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            AssetDatabase.Refresh();
        }


        Texture2D texture = new Texture2D(512, 512);

        // Set the colors of the texture
        texture.SetPixel(0, 0, Color.red);
        texture.SetPixel(5, 6, Color.green);

        // Apply the changes to the texture
        texture.Apply();


        string texturePath = $"{folderPath}/Texture.asset";
        AssetDatabase.CreateAsset(texture, texturePath);

        // Refresh the asset database to ensure the new material appears in the project view
        AssetDatabase.Refresh();

        Debug.Log("new texture created");

        return texture;
    }

    private static Mesh CreateFlatColoredMesh(Mesh mesh)
    {
        // Create the folder path
        string folderPath = "Assets/Resources/FlatColorizer/Mesh";

        // Check if the folder exists, and create it if it doesn't
        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            AssetDatabase.Refresh();
        }

        Mesh flatColoredMesh = new Mesh();
        flatColoredMesh.vertices = mesh.vertices;
        flatColoredMesh.triangles = mesh.triangles;
        flatColoredMesh.uv = mesh.uv;
        flatColoredMesh.normals = mesh.normals;
        flatColoredMesh.colors = mesh.colors;
        flatColoredMesh.tangents = mesh.tangents;

        string materialPath = $"{folderPath}/{FLAT_COLORED}{mesh.name}.asset";
        AssetDatabase.CreateAsset(flatColoredMesh, materialPath);

        AssetDatabase.Refresh();

        Debug.Log("new mesh created");
        return flatColoredMesh;
    }

    public static Material GetSharedMaterial()
    {
        Material sharedMat = Resources.Load<Material>("FlatColorizer/Material/SharedMat");
        if (sharedMat == null)
            sharedMat = CreateMaterial();

        return sharedMat;
    }

    public static Texture2D GetTexture()
    {
        Texture2D texture = Resources.Load<Texture2D>("FlatColorizer/Material/Texture/Texture");
        if (texture == null)
            texture = CreateTexture();
        return texture;
    }

    public static Mesh GetFlatColorizedMesh(Mesh mesh)
    {
        if (mesh.name.Contains(FLAT_COLORED))
            return mesh;

        Mesh flatColoredMesh = Resources.Load<Mesh>($"FlatColorizer/Mesh/{FLAT_COLORED}{mesh.name}.asset");
        if (flatColoredMesh == null)
            flatColoredMesh = CreateFlatColoredMesh(mesh);

        return flatColoredMesh;
    }
}
