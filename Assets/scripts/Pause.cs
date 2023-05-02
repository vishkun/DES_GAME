using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseCanvas;
    public Button resumeButton;
    public Button quitButton;

    private bool isPaused = false;

    void Start()
    {
        // Get reference to the buttons in the PauseCanvas
        resumeButton = pauseCanvas.transform.Find("ResumeButton").GetComponent<Button>();
        quitButton = pauseCanvas.transform.Find("QuitButton").GetComponent<Button>();

        // Add event listeners to the buttons
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);

        // Hide the PauseCanvas at the start of the game
        pauseCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        // Display the PauseCanvas
        pauseCanvas.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        // Hide the PauseCanvas
        pauseCanvas.SetActive(false);
    }

    void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        /*Application.Quit();*/
    }
}