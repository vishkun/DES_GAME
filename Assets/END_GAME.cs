using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class END_GAME : MonoBehaviour
{
    public GameObject videoPlayer,sound;
    public int timetoStop;
    public VideoPlayer play;
    public GameObject canvas;
    //public AudioClip s;

    void Start()
    {
       // videoPlayer.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D player)
    {

        if (player.gameObject.tag == "Player")
        {
            sound.SetActive(false);
            canvas.SetActive(true);
            play.Play();
            videoPlayer.SetActive(true);
            Invoke("quit", 40.0f);

        }
    }

    



    
    private void quit()
    {
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
    #endif
    Application.Quit();

    }
    


}