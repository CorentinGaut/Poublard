using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    public Image voile;

    private float timeCount = 0;
    private float fadeOut = 0;

    // Update is called once per frame
    void Update()
    {
        fadeOut += 0.15f * Time.deltaTime;
        timeCount += Time.deltaTime;
        if (timeCount <= 7f)
        {
            voile.color = new Color(voile.color.r, voile.color.g, voile.color.b, fadeOut);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
