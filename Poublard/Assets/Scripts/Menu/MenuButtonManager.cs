using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{

    private void Update()
    {
        Debug.Log(Input.GetAxisRaw("Vertical"));
    }
    public void Quitter()
    {
        Application.Quit();
    }

    public void Jouer()
    {
        SceneManager.LoadScene("PlayerLobby");
    }
}
