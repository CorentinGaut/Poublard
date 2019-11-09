using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public int totalNbTrash;
    public int nbTrashPicked;

    public int nbTrashRequired;
    public float completionPercentageRequired;
    public int nbPlayers;

    public int[] scoresPlayers;

    public float time;

    public Text txtGlobalScore;
    public Text txtTimer;
    public Image imageGlobalScore;
    // Start is called before the first frame update
    void Start()
    {
        scoresPlayers = new int[nbPlayers];
        txtTimer.text = ((int)time).ToString();
        nbTrashPicked = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        txtTimer.text = ((int)time).ToString();
    }

    public void TrashPickUp(int nbPlayer)
    {
        scoresPlayers[nbPlayer-1]++;
                nbTrashRequired = (int)((float)totalNbTrash *completionPercentageRequired/100.0f);

        nbTrashPicked++;
        float fillAmount = (float)nbTrashPicked / (float)nbTrashRequired;
        txtGlobalScore.text = ((int)(fillAmount * 100.0f)).ToString()+"%";
        imageGlobalScore.fillAmount = fillAmount;
        imageGlobalScore.color = new Vector4(1 -  fillAmount, 1 * fillAmount, 0,1);
    }
}
