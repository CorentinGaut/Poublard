using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLobbyManager : MonoBehaviour
{
    public Canvas player1SelectionCanvas;
    public Canvas player2SelectionCanvas;
    public Canvas player3SelectionCanvas;
    public Canvas player4SelectionCanvas;

    public GameManager gameManager;

    private int nbPlayer = 0;

    private bool player1play = false;
    private bool player2play = false;
    private bool player3play = false;
    private bool player4play = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Character 1 Submit"))
        {
            if (player1play == false)
            {
                player1SelectionCanvas.transform.Find("texts").gameObject.SetActive(false);
                player1SelectionCanvas.transform.Find("playerImage").gameObject.SetActive(true);
                player1play = true;
                nbPlayer++;
            }
            else
            {
                player1SelectionCanvas.transform.Find("texts").gameObject.SetActive(true);
                player1SelectionCanvas.transform.Find("playerImage").gameObject.SetActive(false);
                player1play = false;
                nbPlayer--;
            }
        }

        if (Input.GetButtonDown("Character 2 Submit"))
        {
            Debug.Log("blblbl");
            if (player2play == false)
            {
                player2SelectionCanvas.transform.Find("texts").gameObject.SetActive(false);
                player2SelectionCanvas.transform.Find("playerImage").gameObject.SetActive(true);
                player2play = true;
                nbPlayer++;
            }
            else
            {
                player2SelectionCanvas.transform.Find("texts").gameObject.SetActive(true);
                player2SelectionCanvas.transform.Find("playerImage").gameObject.SetActive(false);
                player2play = false;
                nbPlayer--;
            }
        }

        if (Input.GetButtonDown("Character 3 Submit"))
        {
            if (player3play == false)
            {
                player3SelectionCanvas.transform.Find("texts").gameObject.SetActive(false);
                player3SelectionCanvas.transform.Find("playerImage").gameObject.SetActive(true);
                player3play = true;
                nbPlayer++;
            }
            else
            {
                player3SelectionCanvas.transform.Find("texts").gameObject.SetActive(true);
                player3SelectionCanvas.transform.Find("playerImage").gameObject.SetActive(false);
                player3play = false;
                nbPlayer--;
            }
        }

        if (Input.GetButtonDown("Character 4 Submit"))
        {
            if (player4play == false)
            {
                player4SelectionCanvas.transform.Find("texts").gameObject.SetActive(false);
                player4SelectionCanvas.transform.Find("playerImage").gameObject.SetActive(true);
                player4play = true;
                nbPlayer++;
            }
            else
            {
                player4SelectionCanvas.transform.Find("texts").gameObject.SetActive(true);
                player4SelectionCanvas.transform.Find("playerImage").gameObject.SetActive(false);
                player4play = false;
                nbPlayer--;
            }
        }




        //VALIDATION DE LA SELECTION
        if (nbPlayer == 1)
        {
            if (Input.GetButtonDown("Character 1 Start"))
            {
                SceneManager.LoadScene(2);
            }
        }
        else if (nbPlayer == 2)
        {
            if (Input.GetButtonDown("Character 1 Start") || Input.GetButtonDown("Character 2 Start"))
            {
                SceneManager.LoadScene(2);
            }
        }
        else if (nbPlayer == 3)
        {
            if (Input.GetButtonDown("Character 1 Start") || Input.GetButtonDown("Character 2 Start") || Input.GetButtonDown("Character 3 Start"))
            {
                SceneManager.LoadScene(2);
            }
        }
        else if (nbPlayer == 4)
        {
            if (Input.GetButtonDown("Character 1 Start") || Input.GetButtonDown("Character 2 Start") || Input.GetButtonDown("Character 3 Start") || Input.GetButtonDown("Character 4 Start"))
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
