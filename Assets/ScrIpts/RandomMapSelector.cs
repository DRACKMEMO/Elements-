using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Required for using IEnumerator

public class RandomMapSelector : MonoBehaviour
{
    public Image[] images; // Array to hold the images.
    public Animator[] animators;

    void Start()
    {
        StartCoroutine(SelectRandomImageAfterDelay(7f)); // Start the coroutine with a 7-second delay.
    }

    private IEnumerator SelectRandomImageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay.

        SelectRandomImage(); // Call the method to select a random image.
    }

    void SelectRandomImage()
    {
        if (images.Length == 0) // Check if the images array is not empty.
        {
            Debug.Log("No maps available to select.");
            return;
        }

        int randomIndex = Random.Range(0, images.Length); // Generate a random index based on the number of images.

        Debug.Log($"Map {randomIndex + 1} was selected."); // Log the selected image number (+1 since index number is less by 1).

        // Change the size and position of the selected image
        Image selectedImage = images[randomIndex];
        selectedImage.rectTransform.sizeDelta = new Vector2(800, 800); // Set width and height to 250 units
        selectedImage.rectTransform.anchoredPosition = new Vector2(900, 0); // Set position to (350, 0)

        // Destroy the other images
        for (int i = 0; i < images.Length; i++)
        {
            if (i != randomIndex)
            {
                Destroy(images[i].gameObject); // Destroy the unselected images
            }
        }

        for (int i = 0; i < animators.Length; i++)
        {
            Destroy(animators[i].GetComponent<Animator>());
        }
    }
}