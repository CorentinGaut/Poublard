using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioClip selectSound;

    private List<GameObject> buttons;
    private int currentIndex;
    private int maxIndex;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();


        buttons = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name.Contains("Button"))
            {
                buttons.Add(transform.GetChild(i).gameObject);
            }
        }

        currentIndex = 0;
        maxIndex = buttons.Count - 1;

        buttons[currentIndex].GetComponent<Animator>().SetBool("selected", true);   
    }

    //regarde si la souris est sur un bouton. Si oui elle renvoie true et change l'index.
    public bool CheckMouseHoverButtons()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        for (int i = 0; i < raycastResults.Count; i++)
        {
            ButtonManager button = raycastResults[i].gameObject.transform.parent.GetComponent<ButtonManager>();
            if (button != null && button.GetButtonIndex() != currentIndex)
            {
                currentIndex = button.GetButtonIndex();
                return true;
            }
        }
        return false;
    }

    public void SetSelected(int index)
    {
        PlaySound(selectSound);

        for (int i = 0; i < buttons.Count; i++)
        {
            if (i == index)
            {
                buttons[i].GetComponent<Animator>().SetBool("selected", true);
            }
            else
            {
                buttons[i].GetComponent<Animator>().SetBool("selected", false);
            }
        }
    }

    public void PlaySound(AudioClip sound)
    {
        audioSource.clip = sound;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
     {

         if (Input.GetKeyDown(KeyCode.S)) //BAS
         {
             //incrémentation
             currentIndex++;
             if (currentIndex > maxIndex)
             {
                 currentIndex = 0;
             }

            SetSelected(currentIndex);
         }
         if(Input.GetKeyDown(KeyCode.Z))//HAUT
         {
             //décrémentation
             currentIndex--;
             if (currentIndex < 0)
             {
                 currentIndex = maxIndex;
             }

            SetSelected(currentIndex);
         }

         if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
         {
            ButtonManager btn = buttons[currentIndex].GetComponent<ButtonManager>();
            if (btn.GetAction() == ButtonManager.ACTIONS.LoadScene)
            {
                Debug.Log("load scene");
                SceneManager.LoadScene(btn.GetSceneName());
            }
            else if (btn.GetAction() == ButtonManager.ACTIONS.Quit)
            {
                Application.Quit();
                Debug.Log("quit");
            }
         }

        if (CheckMouseHoverButtons())
        {
            SetSelected(currentIndex);
        }
     }

}
