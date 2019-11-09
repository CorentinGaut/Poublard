using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MenuGenerator))]
public class MenuGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MenuGenerator menuGenerator = (MenuGenerator)target;

        if (GUILayout.Button("Generate Menu"))
        {
            menuGenerator.CreateMenu();
        }
    }
}
