using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


public static class FlatColorizerManager
{
#if UNITY_EDITOR
    private const string FLAT_COLORED = "FlatColored_";

    private static void EnsureFileCreation(string folderPath)
    {
        // Check if the folder exists, and create it if it doesn't
        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            AssetDatabase.Refresh();
        }
    }

    private static Material CreateMaterial()
    {
        string folderPath = "Assets/Resources/FlatColorizer/Material";

        EnsureFileCreation(folderPath);

        // Create a new material
        Material newMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        newMaterial.mainTexture = GetTexture();
        newMaterial.SetFloat("_Smoothness", 0.25f);

        // Save the material to a file
        string materialPath = $"{folderPath}/SharedMat.mat";
        AssetDatabase.CreateAsset(newMaterial, materialPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("new material created");
        return newMaterial;
    }

    private static Texture2D CreateTexture()
    {
        string folderPath = "Assets/Resources/FlatColorizer/Texture";

        EnsureFileCreation(folderPath);

        // Create a new texture
        Texture2D texture = new Texture2D(512, 512, TextureFormat.RGBA32, false);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Point;
        texture.Apply();

        // Save the texture to a file
        string texturePath = $"{folderPath}/Texture.asset";
        AssetDatabase.CreateAsset(texture, texturePath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("new texture created");
        return texture;
    }

    private static Mesh CreateFlatColoredMesh(Mesh mesh)
    {
        string filePath = "Assets/Resources/FlatColorizer/Mesh";

        EnsureFileCreation(filePath);

        // Create a new mesh
        Mesh flatColoredMesh = new Mesh();
        flatColoredMesh.vertices = mesh.vertices;
        flatColoredMesh.triangles = mesh.triangles;
        flatColoredMesh.uv = mesh.uv;
        flatColoredMesh.normals = mesh.normals;
        flatColoredMesh.colors = mesh.colors;
        flatColoredMesh.tangents = mesh.tangents;

        // Save the mesh to a file
        string meshPath = $"{filePath}/{FLAT_COLORED}{mesh.name}.asset";
        AssetDatabase.CreateAsset(flatColoredMesh, meshPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        CreateFlatColoredMeshData(flatColoredMesh);

        Debug.Log("new mesh created");
        return flatColoredMesh;
    }

    private static FlatColoredMeshData CreateFlatColoredMeshData(Mesh flatColoredMesh)
    {
        string filePath = "Assets/Resources/FlatColorizer/Mesh/MeshData";

        EnsureFileCreation(filePath);

        // Create a new mesh data
        FlatColoredMeshData flatColoredMeshData = ScriptableObject.CreateInstance<FlatColoredMeshData>();


        // Save the mesh data to a file
        string meshDataPath = Path.Combine(filePath, flatColoredMesh.name + "_data" + ".asset");
        AssetDatabase.CreateAsset(flatColoredMeshData, meshDataPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        flatColoredMeshData.SetData(flatColoredMesh);

        Debug.Log("new FlatColoredMeshData created");
        return flatColoredMeshData;
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
        Texture2D texture = Resources.Load<Texture2D>("FlatColorizer/Texture/Texture");
        if (texture == null)
            texture = CreateTexture();
        return texture;
    }

    public static Mesh GetFlatColorizedMesh(Mesh mesh)
    {
        if (mesh.name.Contains(FLAT_COLORED))
            return mesh;

        string meshName = mesh.name.Contains(FLAT_COLORED) ? mesh.name : FLAT_COLORED + mesh.name;

        Mesh flatColoredMesh = Resources.Load<Mesh>($"FlatColorizer/Mesh/{meshName}");
        if (flatColoredMesh == null)
            flatColoredMesh = CreateFlatColoredMesh(mesh);

        return flatColoredMesh;
    }

    public static FlatColoredMeshData GetMeshData(Mesh mesh)
    {
        FlatColoredMeshData meshData = Resources.Load<FlatColoredMeshData>($"FlatColorizer/Mesh/MeshData/{mesh.name + "_data"}");
        if (meshData == null)
            Debug.LogWarning($"{mesh.name}_data not found");

        return meshData;
    }

    public static FlatColoredMeshData[] GetAllMeshesData()
    {
        return Resources.LoadAll<FlatColoredMeshData>($"FlatColorizer/Mesh/MeshData");
    }

#endif
}
