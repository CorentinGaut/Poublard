using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public enum ACTIONS { LoadScene, Quit};

    [HideInInspector]
    public int buttonIndex;
    private string sceneName;
    private ACTIONS action;
    [HideInInspector]
    public int actionIndex;

    private void Start()
    {
        action = ACTIONS.Quit;
    }

    public int GetButtonIndex()
    {
        return buttonIndex;
    }

    public void SetButtonIndex(int index)
    {
        buttonIndex = index;
    }

    public string GetSceneName()
    {
        return sceneName;
    }

    public void SetSceneName(string str)
    {
        sceneName = str;
    }

    public ACTIONS GetAction()
    {
        return action;
    }

    public void SetAction(ACTIONS act)
    {
        action = act;
    }

    public int GetActionIndex()
    {
        return actionIndex;
    }

    public void SetActionIndex(int i)
    {
        actionIndex = i;
    }
}
