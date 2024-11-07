using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_Manager : MonoBehaviour
{
    // Reference to the buttons
    public Button playButton;
    public Button settingsButton;
    public Button quitButton;

    void Start()
    {
        // Add listeners to the buttons
        playButton.onClick.AddListener(OnPlayButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    void OnPlayButtonClicked()
    {
        // Load the game scene (replace "GameScene" with your actual game scene name)
        SceneManager.LoadScene("GameScene");
    }

    void OnSettingsButtonClicked()
    {
        // Load settings scene or open settings menu
        // For now, we can just log to the console
        Debug.Log("Settings button clicked!");
        // You can implement settings functionality here
    }

    void OnQuitButtonClicked()
    {
        // Quit the application
        Application.Quit();

        // If running in the editor, stop playing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
