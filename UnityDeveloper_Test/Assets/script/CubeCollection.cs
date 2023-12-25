using UnityEngine;
using UnityEngine.UI;


public class CubeCollection : MonoBehaviour
{
    public int totalCubes = 5; // Set the total number of cubes in the level
    private int collectedCubes = 0;
    public Text collectedtext;
    public Text victoryText;
    public Timer timerScript;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);

        if (other.CompareTag("Cube"))
        {
            // Assuming the collider is on the player
             CollectCube();
            Destroy(other.gameObject);
            Debug.Log("cube tackle"); 
        }
    }

    void CollectCube()
    {
        // Handle cube collection logic
        collectedCubes++;
        collectedtext.text="Collected:"+collectedCubes.ToString();

        Debug.Log("Cube collected! Total collected: " + collectedCubes);
        

        // Check if all cubes are collected
        if (collectedCubes == totalCubes)
        {
            // Level complete logic (e.g., load next level or show victory message)
            Debug.Log("Level Complete!");
            // Level complete logic (e.g., show victory message)
            ShowVictoryMessage();
            // Optionally, you can deactivate the cube instead of destroying it

        }

        
    }
    void ShowVictoryMessage()
    {
        // Activate the victory text
        victoryText.gameObject.SetActive(true);
        
        // Optional: You can perform additional actions here, such as loading the next level or triggering other events.
       timerScript.GameWon();
        Debug.Log("Level Complete!");
       ;
    }
}
