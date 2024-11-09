using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Characters;
    private int characterIndex;
    
    public void ChaneCharacter(int index)
    {
        for(int i = 0; i < Characters.Length; i++) 
        {
            Characters[i].SetActive(false);
        }
        this.characterIndex = index;
        Characters[index].SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("CharacterIndex", characterIndex);
    }
}
