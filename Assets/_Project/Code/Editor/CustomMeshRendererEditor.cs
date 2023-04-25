using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshRenderer))]
public class CustomMeshRendererEditor : Editor
{
    private FlatColorizer _flatColorizer;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(10f);

        MeshRenderer meshRenderer = serializedObject.targetObject as MeshRenderer;

        if (_flatColorizer == null)
            _flatColorizer = meshRenderer.GetComponent<FlatColorizer>();

        if (_flatColorizer == null && GUILayout.Button($"Add {nameof(FlatColorizer)}"))
        {
            _flatColorizer = meshRenderer.gameObject.AddComponent<FlatColorizer>();
        }
    }
}