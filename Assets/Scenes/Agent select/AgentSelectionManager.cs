using UnityEngine;
using UnityEngine.UI;

public class AgentSelectionManager : MonoBehaviour
{
    public Button[] player1Buttons; // Buttons for player 1 agent selection
    public Button[] player2Buttons; // Buttons for player 2 agent selection
    public Button nextButton; // Button to confirm and spawn agents
    public GameObject[] agentPrefabs; // Array of agent prefabs to spawn
    public Transform player1SpawnPoint; // Spawn point for player 1
    public Transform player2SpawnPoint; // Spawn point for player 2
    public Canvas selectionCanvas; // Reference to the selection canvas to disable it

    private int player1Selection = -1;
    private int player2Selection = -1;

    void Start()
    {
        nextButton.onClick.AddListener(OnNextButtonClicked);

        // Add listeners to player selection buttons
        for (int i = 0; i < player1Buttons.Length; i++)
        {
            int index = i; // Local copy for the listener
            player1Buttons[i].onClick.AddListener(() => OnPlayer1AgentSelected(index));
        }

        for (int i = 0; i < player2Buttons.Length; i++)
        {
            int index = i; // Local copy for the listener
            player2Buttons[i].onClick.AddListener(() => OnPlayer2AgentSelected(index));
        }
    }

    // When player 1 selects an agent
    void OnPlayer1AgentSelected(int index)
    {
        player1Selection = index;
        Debug.Log("Player 1 selected agent: " + (index + 1));
    }

    // When player 2 selects an agent
    void OnPlayer2AgentSelected(int index)
    {
        player2Selection = index;
        Debug.Log("Player 2 selected agent: " + (index + 1));
    }

    // When Next button is clicked, spawn agents and hide the selection canvas
    void OnNextButtonClicked()
    {
        if (player1Selection == -1 || player2Selection == -1)
        {
            Debug.LogError("Both players need to select an agent!");
            return;
        }

        // Spawn agents at the respective spawn points
        Instantiate(agentPrefabs[player1Selection],  .position, Quaternion.identity);
        Instantiate(agentPrefabs[player2Selection], player2SpawnPoint.position, Quaternion.identity);

        // Disable the selection canvas to hide UI elements
        selectionCanvas.gameObject.SetActive(false);

        Debug.Log("Agents spawned and canvas disabled.");
    }
}

