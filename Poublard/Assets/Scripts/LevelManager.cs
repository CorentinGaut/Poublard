using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public AudioClip levelMusic;

    public int totalNbTrash;
    public int nbTrashPicked;

    public int nbTrashRequired;
    public float completionPercentageRequired;
    public int nbPlayers;

    public int[] scoresPlayers;
    public Text[] scoresPlayersEnd;
    public Sprite[] rankImages;
    public Image[] rankImagesEnd;
    public int[] rankPlayers;
    public Transform[] SpawnPoints;
    public GameObject[] bennes;
    public CharController[] Characters;
    public GameObject[] uiTrash;


    public float time;
    public bool scoreDisplayed;

    public Text txtGlobalScore;
    public Text txtGlobalScoreEnd;
    public GameObject panelEndVictory;
    public GameObject panelEndDefeat;

    public Text txtTimer;
    public Image imageGlobalScore;

    public Canvas endGameCanvas;
    // Start is called before the first frame update


    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //nbPlayers = GameManager.nbPlayer;
        //nbPlayers = 3;
        scoreDisplayed = false;
        scoresPlayers = new int[nbPlayers];
        txtTimer.text = ((int)time).ToString();
        nbTrashPicked = 0;
       // SpawnPlayers();
        SpawnBennes();
        SpawnUI();
    }

    public void SpawnPlayers()
    {
        for (int i = 0; i < nbPlayers; i++)
        {
            SpawnPlayer(i);
        }
    }

    public void SpawnBennes()
    {
        for (int i = 0; i < nbPlayers; i++)
        {
            bennes[i].SetActive(true);
        }
    }

    public void SpawnUI()
    {
        for (int i = 0; i < nbPlayers; i++)
        {
            uiTrash[i].SetActive(true);

        }
    }

    public void SpawnPlayer(int i)
    {
        Characters[i].transform.position = SpawnPoints[i].position;
        Characters[i].Play();
        CameraZoom.instance.targets.Add(Characters[i].transform);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        txtTimer.text = ((int)time).ToString();

        if (time <= 0) //fin de partie
        {
            Time.timeScale = 0f;
            if(scoreDisplayed == false)
            {
                endGameCanvas.gameObject.SetActive(true);
                DisplayWinners();
                scoreDisplayed = true;
            }

        }
    }

    public void TrashPickUp(int nbPlayer)
    {
        if (nbPlayer >= nbPlayers)
            return;
        scoresPlayers[nbPlayer-1]++;
                nbTrashRequired = (int)((float)totalNbTrash *completionPercentageRequired/100.0f);

        nbTrashPicked++;
        float fillAmount = (float)nbTrashPicked / (float)nbTrashRequired;
        txtGlobalScore.text = ((int)(fillAmount * 100.0f)).ToString()+"%";
        imageGlobalScore.fillAmount = fillAmount;
        imageGlobalScore.color = new Vector4(1 -  fillAmount, 1 * fillAmount, 0,1);
    }

    public void DisplayWinners()
    {
        RankPlayers();
        txtGlobalScoreEnd.text += ((int)((float)nbTrashPicked*100 / (float)nbTrashRequired)).ToString() + "%" ;
        if ((float) nbTrashPicked / (float)nbTrashRequired>=1)
        {
            panelEndVictory.SetActive(true);
            panelEndDefeat.SetActive(false);
        }
        else
        {
            panelEndVictory.SetActive(false);
            panelEndDefeat.SetActive(true);
        }
    }

    private void RankPlayers()
    {
        rankPlayers = new int[nbPlayers];
        for (int i = 0; i < nbPlayers; i++)
        {
            int maxScorePlayer = -1;
            int indexStrongestPlayer = -1;
            for(int j = 0;j<nbPlayers;j++)
            {
                if(maxScorePlayer< scoresPlayers[j])
                {
                    maxScorePlayer = scoresPlayers[j];
                    indexStrongestPlayer = j;
                }
            }
            scoresPlayersEnd[indexStrongestPlayer].text += maxScorePlayer;
            rankImagesEnd[indexStrongestPlayer].sprite = rankImages[i];
            scoresPlayers[indexStrongestPlayer] = -2;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
