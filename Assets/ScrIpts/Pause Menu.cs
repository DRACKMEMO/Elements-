using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button resumeButton;
    public Button mainMenuButton;
    public GameObject confirmationPopup;

    private void Start()
    {
        resumeButton.onClick.AddListener(Resume);
        mainMenuButton.onClick.AddListener(ShowConfirmationPopup);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1; // Ensure the game is running
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (pauseMenuUI.activeSelf)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1; // Resume the game
    }

    private void ShowConfirmationPopup()
    {
        confirmationPopup.SetActive(true);
    }

    public void ConfirmMainMenu()
    {
        Time.timeScale = 1; // Ensure the game is running before loading a new scene
        SceneManager.LoadScene("MainMenu"); // Replace with your main menu scene name
    }

    public void Cancel()
    {
        confirmationPopup.SetActive(false);
    }
}