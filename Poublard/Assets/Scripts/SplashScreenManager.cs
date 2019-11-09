using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SplashScreenManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI presented;
    public TextMeshProUGUI names;

    public float TimeTitleSpawn;
    public float TimePresentedSpawn;
    public float TimeNamesSpawn;

    private float timeCount = 0;

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount < TimeTitleSpawn)
        {
            title.GetComponent<RectTransform>().localScale = new Vector3(0.3f * timeCount, 0.3f * timeCount, 0);
        }
        else
        {
        }
    }
}
