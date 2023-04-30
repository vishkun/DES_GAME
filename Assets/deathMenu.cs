using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;

public class deathMenu : MonoBehaviour
{
    public GameObject deathCanvas;
    public GameObject startCanvas;

    public PlayerHealth playerHealth;
    private all_keys keyCount;

    public Button quit;
    public Button restartGame;

    //public GameObject startMenu;

    // Start is called before the first frame update
    void Start()
    {
        restartGame = deathCanvas.transform.Find("continueButton").GetComponent<Button>();
        restartGame.onClick.AddListener(ResetGame);

        quit = deathCanvas.transform.Find("quitButton").GetComponent<Button>();
        quit.onClick.AddListener(QuitGame);

        //startMenu = GameObject.Find("StartMenu");

        deathCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.health == 1)
        {
            deathCanvas.SetActive(true);
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Scene is reset");
            
        all_keys.keyCount = 0;
        print("key value reset");

        
    }

    void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}


