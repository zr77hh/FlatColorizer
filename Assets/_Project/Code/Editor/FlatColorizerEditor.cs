using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FlatColorizer))]
public class FlatColorizerEditor : Editor
{
    private SerializedProperty _colorsProperty;
    private FlatColorizer _flatColorizer;

    private void OnEnable()
    {
        _flatColorizer = serializedObject.targetObject as FlatColorizer;
        _colorsProperty = serializedObject.FindProperty(nameof(FlatColorizer._color));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        for (int i = 0; i < _colorsProperty.arraySize; i++)
        {
            SerializedProperty colorProperty = _colorsProperty.GetArrayElementAtIndex(i);
            Color colorValue = colorProperty.colorValue;

            EditorGUI.BeginChangeCheck();

            colorValue = EditorGUILayout.ColorField("Color " + i, colorValue);

            if (EditorGUI.EndChangeCheck())
            {
                colorProperty.colorValue = colorValue;
                _flatColorizer.FlatColorize();
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
