using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLobbyManager : MonoBehaviour
{
    public GameObject[] playerSelections = new GameObject[4];

    public AudioClip clip;

    public Image fadeoutPanel;

    private int nbPlayer = 0;

    private int[] playerInputId = new int[4];

    private bool[] inputId = new bool[4];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerInputId.Length; i++)
        {
            playerInputId[i] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Character 1 Submit") && inputId[0] == false)
        {
            Debug.Log("Manette 1");
            playerSelections[nbPlayer].transform.Find("pressAToJoin").gameObject.SetActive(false);
            playerSelections[nbPlayer].transform.Find("playerDummy").gameObject.SetActive(true);
            playerInputId[nbPlayer] = 1;
            inputId[0] = true;
            nbPlayer++;
        }

        if (Input.GetButtonDown("Character 2 Submit") && inputId[1] == false)
        {
            Debug.Log("Manette 2");
            playerSelections[nbPlayer].transform.Find("pressAToJoin").gameObject.SetActive(false);
            playerSelections[nbPlayer].transform.Find("playerDummy").gameObject.SetActive(true);
            playerInputId[nbPlayer] = 2;
            inputId[1] = true;
            nbPlayer++;
        }

        if (Input.GetButtonDown("Character 3 Submit")&& inputId[2] == false)
        {
            Debug.Log("Manette 3");
            playerSelections[nbPlayer].transform.Find("pressAToJoin").gameObject.SetActive(false);
            playerSelections[nbPlayer].transform.Find("playerDummy").gameObject.SetActive(true);
            playerInputId[nbPlayer] = 3;
            inputId[2] = true;
            nbPlayer++;
        }

        if (Input.GetButtonDown("Character 4 Submit") && inputId[3] == false)
        {
            Debug.Log("Manette 4");
            playerSelections[nbPlayer].transform.Find("pressAToJoin").gameObject.SetActive(false);
            playerSelections[nbPlayer].transform.Find("playerDummy").gameObject.SetActive(true);
            playerInputId[nbPlayer] = 4;
            inputId[3] = true;
            nbPlayer++;
        }



        //VALIDATION DE LA SELECTION
        if (Input.GetButtonDown("Character 1 Start") || Input.GetButtonDown("Character 2 Start") || Input.GetButtonDown("Character 3 Start")|| Input.GetButtonDown("Character 4 Start"))
        {
            for (int i = 0; i < playerInputId.Length; i++)
            {
                Debug.Log(i +" :" +playerInputId[i]);
            }

            if (clip != null)
            {
                GameObject.Find("GameManager").GetComponent<AudioSource>().loop = false;
                GameObject.Find("GameManager").GetComponent<AudioSource>().clip = clip;
                GameObject.Find("GameManager").GetComponent<AudioSource>().Play();
            }



            StartCoroutine("FadeOutAndLoadScene");
        }
    }

    public IEnumerator FadeOutAndLoadScene()
    {
        fadeoutPanel.color = new Color(fadeoutPanel.color.r, fadeoutPanel.color.g, fadeoutPanel.color.b, fadeoutPanel.color.a + 0.6f);

        yield return new WaitForSeconds(2f);

        GameManager.playersInputId = playerInputId;
        GameManager.nbPlayer = nbPlayer;
        SceneManager.LoadScene("Corentin");
    }
}
    