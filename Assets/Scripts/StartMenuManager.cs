using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("TheWorld"); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); 
    }
}
