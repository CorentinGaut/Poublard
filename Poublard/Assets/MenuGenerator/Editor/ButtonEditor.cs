using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ButtonManager))]
public class ButtonEditor : Editor
{
    private string sceneName;
    private Object obj;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ButtonManager buttonManager = (ButtonManager)target;

        buttonManager.SetActionIndex(GUILayout.Toolbar(buttonManager.GetActionIndex(), new string[] { "Load Scene", "Quit"}));

        if (buttonManager.GetActionIndex() == 0)
        {
            buttonManager.SetAction(ButtonManager.ACTIONS.LoadScene);

            GUILayout.BeginHorizontal();
                GUILayout.Label("Scene Name : ", GUILayout.Width(100));
                sceneName = GUILayout.TextField(sceneName);
                buttonManager.SetSceneName(sceneName);
            GUILayout.EndHorizontal();
        }
        else if (buttonManager.GetActionIndex() == 1)
        {
            buttonManager.SetAction(ButtonManager.ACTIONS.Quit);
        }
    }
}
