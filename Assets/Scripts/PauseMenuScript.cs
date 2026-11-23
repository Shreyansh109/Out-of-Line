using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    

    void OnInGameMenu()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}