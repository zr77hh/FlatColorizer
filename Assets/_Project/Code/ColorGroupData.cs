using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorGroupData
{
    public List<int> UV_posIndexes = new List<int>();
    public Vector2 pos;
    public Color color;

    public ColorGroupData(Vector2 targetPos)
    {
        UV_posIndexes = new List<int>();
        pos = targetPos;
        color = Color.white;
    }

    public void AddPosIndex(int index)
    {
        if (UV_posIndexes.Contains(index))
            Debug.Log($"the index {index} is already added");

        UV_posIndexes.Add(index);
    }
}
