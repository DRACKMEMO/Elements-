//using UnityEngine;

//public class GameManager : MonoBehaviour
//{
//    [SerializeField] private GameObject[] player1CharacterPrefabs; // Array of Player 1 character prefabs
//    [SerializeField] private GameObject[] player2CharacterPrefabs; // Array of Player 2 character prefabs
//    [SerializeField] private Transform player1SpawnPoint; // Spawn point for Player 1
//    [SerializeField] private Transform player2SpawnPoint; // Spawn point for Player 2

//    void Start()
//    {
//        LoadCharacters();
//    }

//    private void LoadCharacters()
//    {
//        // Retrieve selected character indices from PlayerPrefs
//        int player1Index = PlayerPrefs.GetInt("player1SelectedIndex", 0); // Default to 0 if not set
//        int player2Index = PlayerPrefs.GetInt("player2SelectedIndex", 0); // Default to 0 if not set

//        // Instantiate Player 1 character
//        if (player1Index >= 0 && player1Index < player1CharacterPrefabs.Length)
//        {
//            Instantiate(player1CharacterPrefabs[player1Index], player1SpawnPoint.position, Quaternion.identity);
//        }
//        else
//        {
//            Debug.LogError("Invalid Player 1 character index: " + player1Index);
//        }

//        // Instantiate Player 2 character
//        if (player2Index >= 0 && player2Index < player2CharacterPrefabs.Length)
//        {
//            Instantiate(player2CharacterPrefabs[player2Index], player2SpawnPoint.position, Quaternion.identity);
//        }
//        else
//        {
//            Debug.LogError("Invalid Player 2 character index: " + player2Index);
//        }
//    }
//}
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabs;

    void Start()
    {
        LoadCharacter();
    }



    private void LoadCharacter()
    {
        int characterIndex = PlayerPrefs.GetInt("CharacterIndex");
        Instantiate(characterPrefabs[characterIndex]);
    }
}