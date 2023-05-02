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

    public Animator anim;
    public GameObject player;
    

    //public GameObject startMenu;

    // Start is called before the first frame update
    void Start()
    {
        restartGame = deathCanvas.transform.Find("continueButton").GetComponent<Button>();
        restartGame.onClick.AddListener(ResetGame);

        player = GameObject.FindGameObjectWithTag("Player");
        anim=player.GetComponent<Animator>();
        quit = deathCanvas.transform.Find("quitButton").GetComponent<Button>();
        quit.onClick.AddListener(QuitGame);

        //startMenu = GameObject.Find("StartMenu");

        deathCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.health >1.0f)
        {
            anim.SetTrigger("die");
            //deathCanvas.SetActive(true);
            Invoke("death", 2.0f);
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Scene is reset");
            
        all_keys.keyCount = 0;
        print("key value reset");

        
    }

    



    
        private void death()
        {
            deathCanvas.SetActive(true);

        }

    void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}




