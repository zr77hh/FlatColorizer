using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class FlatColoredMeshData : ScriptableObject
{
    public List<ColorGroupData> colorGroups;


    private void AddToColorGroups(int uvIndex, Vector2 uvPos)
    {
        for (int i = 0; i < colorGroups.Count; i++)
        {
            if (colorGroups[i].pos == uvPos)
            {
                colorGroups[i].AddPosIndex(uvIndex);
                return;
            }
        }

        colorGroups.Add(new ColorGroupData(uvPos));
        colorGroups[colorGroups.Count - 1].AddPosIndex(uvIndex);
    }

    public void SetColorGroupsPositions(Vector2[] positions, Mesh mesh)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            Vector2 curTargetPos = positions[i];
            if (colorGroups[i].pos != curTargetPos)
            {
                colorGroups[i].pos = curTargetPos;

                for (int e = 0; e < colorGroups[i].UV_posIndexes.Count; e++)
                {
                    int uvIndex = colorGroups[i].UV_posIndexes[e];
                    mesh.uv[uvIndex] = curTargetPos;
                }
            }
        }
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }

    public void SetColor(int colorIndex, Color color)
    {
        colorGroups[colorIndex].color = color;
        //EditorUtility.SetDirty(this);
        //AssetDatabase.SaveAssets();
    }

    public void SetData(Mesh mesh)
    {
        colorGroups = new List<ColorGroupData>();

        for (int i = 0; i < mesh.uv.Length; i++)
        {
            AddToColorGroups(i, mesh.uv[i]);
        }

        Debug.Log(colorGroups.Count);
    }
}
