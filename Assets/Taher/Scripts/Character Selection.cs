using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] player1Characters; // Characters for Player 1
    [SerializeField] private GameObject[] player2Characters; // Characters for Player 2
    [SerializeField] private GameObject player1SelectionCanvas; // Canvas for Player 1 selection
    [SerializeField] private GameObject player2SelectionCanvas; // Canvas for Player 2 selection
    [SerializeField] private Button nextButton; // Button to go to Player 2 selection
    [SerializeField] private Button startGameButton; // Button to start the game

    public int player1SelectedIndex = -1; // Track Player 1's selected character index
    public int player2SelectedIndex = -1; // Track Player 2's selected character index

    private void Start()
    {
        // Initially show Player 1 selection canvas and hide Player 2 selection canvas
        player1SelectionCanvas.SetActive(true);
        player2SelectionCanvas.SetActive(false);

        // Add listener to the next button
        nextButton.onClick.AddListener(OnNextButtonClicked);

        // Add listener to the start game button
        startGameButton.onClick.AddListener(StartGame);

        // Ensure the start game button is disabled initially
        startGameButton.interactable = false;
    }

    public void ChangeCharacter(int index)
    {
        // Change the character for Player 1
        if (player1SelectionCanvas.activeSelf)
        {
            for (int i = 0; i < player1Characters.Length; i++)
            {
                player1Characters[i].SetActive(false);
            }
            player1Characters[index].SetActive(true);
            player1SelectedIndex = index; // Store the selected index
        }
        // Change the character for Player 2
        else if (player2SelectionCanvas.activeSelf)
        {
            for (int i = 0; i < player2Characters.Length; i++)
            {
                player2Characters[i].SetActive(false);
            }
            player2Characters[index].SetActive(true);
            player2SelectedIndex = index; // Store the selected index
        }

        // Enable the start game button if both players have selected their characters
        if (player1SelectedIndex != -1 && player2SelectedIndex != -1)
        {
            startGameButton.interactable = true;
        }
    }

    private void OnNextButtonClicked()
    {
        // Hide Player 1 selection canvas and show Player 2 selection canvas
        player1SelectionCanvas.SetActive(false);
        player2SelectionCanvas.SetActive(true);
    }

    private void StartGame()
    {
        // Check if both players have selected their characters
        if (player1SelectedIndex != -1 && player2SelectedIndex != -1)
        {
            Debug.Log("Starting the game with Player 1: " + player1Characters[player1SelectedIndex].name +
                      " and Player 2: " + player2Characters[player2SelectedIndex].name);
            // Load the game scene
            SceneManager.LoadScene("test"); // Replace "GameScene" with your actual game scene name
        }
        else
        {
            Debug.Log("Both players must select a character before starting the game.");
        }
    }

    // Public methods to get selected indices
    public int GetPlayer1SelectedIndex()
    {
        return player1SelectedIndex;
    }

    public int GetPlayer2SelectedIndex()
    {
        return player2SelectedIndex;
    }
}