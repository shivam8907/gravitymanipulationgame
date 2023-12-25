using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLimitInSeconds = 120f; // Set the time limit in seconds
    private float currentTime;

    public Text timerText; // Attach a UI Text component to display the timer
    public GameObject gameOverPanel;// Attach a UI panel to display game over message
    private bool gameWon = false;

    void Start()
    {
        currentTime = timeLimitInSeconds;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else if (!gameWon)
        {
            GameOver();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        // Display game over message or perform game over actions
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game (optional)
        
    }
    void ReloadScene()
    {
        // Reload the current scene
        SceneManager.LoadScene("SampleScene");
    }
    public void GameWon()
    {
        gameWon = true;
        // Optionally, you can add additional logic when the game is won
        Debug.Log("Game Won!");
        Invoke("ReloadScene", 5f);
    }

}
