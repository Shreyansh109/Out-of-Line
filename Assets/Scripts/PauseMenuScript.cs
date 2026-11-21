using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    

    void OnInGameMenu()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
    }
}