using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    public void Quitter()
    {
        Application.Quit();
    }

    public void Jouer()
    {
        SceneManager.LoadScene("PlayerLobby");
    }
}
