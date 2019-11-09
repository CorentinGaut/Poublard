using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    public Image voile;

    private float timeCount = 0;

    // Update is called once per frame
    void Update()
    {
        timeCount += 0.2f * Time.deltaTime;
        if (timeCount <= 2f)
        {
            voile.color = new Color(voile.color.r, voile.color.g, voile.color.b, timeCount);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
