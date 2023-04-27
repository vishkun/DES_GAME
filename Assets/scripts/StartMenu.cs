using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject startCanvas;
    public Button playButton;

    private bool isPaused = false;

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
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }*/
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        // Display the PauseCanvas
        startCanvas.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        // Hide the PauseCanvas
        startCanvas.SetActive(false);
    }

    void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        /*Application.Quit();*/
    }
}