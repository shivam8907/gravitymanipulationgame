using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        // Attach a method to the button's click event
        playButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        // Deactivate the play button
        playButton.gameObject.SetActive(false);

        // Load the game scene (replace "YourGameScene" with the actual scene name)
        SceneManager.LoadScene("SampleScene");
    }
}
