using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FlatColorizer))]
public class FlatColorizerEditor : Editor
{
    private SerializedProperty _colorsProperty;
    private FlatColorizer _flatColorizer;

    private void OnEnable()
    {
        _colorsProperty = serializedObject.FindProperty(nameof(FlatColorizer._color));
        _flatColorizer = serializedObject.targetObject as FlatColorizer;

        if (_flatColorizer != _flatColorizer.GetComponent<FlatColorizer>())
        {
            Debug.LogError($"there is already a {nameof(FlatColorizer)} component");
            DestroyImmediate(_flatColorizer);
            return;
        }

        _flatColorizer.FlatColorize();
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
                _flatColorizer.UpdateColor(i, colorValue);
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
