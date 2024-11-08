using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [Header("Player UI")]
    [SerializeField] private Image player1HealthBar; // Image for Player 1's health bar
    [SerializeField] private Image player2HealthBar; // Image for Player 2's health bar

    [Header("Character Images")]
    [SerializeField] private Sprite[] characterSprites; // Array of character images

    private int player1SelectedCharacter = -1; // Index of Player 1's selected character
    private int player2SelectedCharacter = -1; // Index of Player 2's selected character

    // Call this method when Player 1 selects a character
    public void SelectPlayer1Character(int characterIndex)
    {
        if (characterIndex >= 0 && characterIndex < characterSprites.Length)
        {
            player1SelectedCharacter = characterIndex;
            UpdateHealthBarImages();
        }
    }

    // Call this method when Player 2 selects a character
    public void SelectPlayer2Character(int characterIndex)
    {
        if (characterIndex >= 0 && characterIndex < characterSprites.Length)
        {
            player2SelectedCharacter = characterIndex;
            UpdateHealthBarImages();
        }
    }

    // Update the health bar images based on selected characters
    private void UpdateHealthBarImages()
    {
        if (player1SelectedCharacter >= 0)
        {
            player1HealthBar.sprite = characterSprites[player1SelectedCharacter];
        }

        if (player2SelectedCharacter >= 0)
        {
            player2HealthBar.sprite = characterSprites[player2SelectedCharacter];
        }
    }
}