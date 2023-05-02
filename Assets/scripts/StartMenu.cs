using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject startCanvas;
    public Button playButton;

    public bool isPaused = false;

    void Start()
    {
        // Get reference to the buttons in the PauseCanvas
        playButton = startCanvas.transform.Find("startButton").GetComponent<Button>();

        // Add event listeners to the buttons
        playButton.onClick.AddListener(ResumeGame);

        // Hide the PauseCanvas at the start of the game
        PauseGame();
    }

    void Update()
    {
        
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        // Display the PauseCanvas
        startCanvas.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        // Hide the PauseCanvas
        startCanvas.SetActive(false);
    }
}