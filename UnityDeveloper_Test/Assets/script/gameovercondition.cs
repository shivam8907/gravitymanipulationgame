using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Transform player;      // Reference to the player's transform
    public float fallThreshold = -10f; // Set the Y-axis threshold for considering the player fallen

    void Update()
    {
        // Check if the player has fallen below the threshold
        if (player.position.y < fallThreshold)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Implement game over logic here, such as showing a game over screen, resetting the level, etc.
        Debug.Log("Game Over - Player fell!");
        SceneManager.LoadScene("SampleScene");
    }
}
