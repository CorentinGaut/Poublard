using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int totalNbTrash;
    public int nbTrashPicked;

    public int nbTrashRequired;
    public float completionPercentageRequired;
    public int nbPlayers;

    public int[] scoresPlayers;
    public Transform[] SpawnPoints;
    public GameObject[] bennes;
    public CharController[] Characters;
    public GameObject[] uiTrash;

    public float time;

    public Text txtGlobalScore;
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
            endGameCanvas.gameObject.SetActive(true);
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

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
