using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class END_GAME : MonoBehaviour
{
    public GameObject videoPlayer;
    public int timetoStop;
    public VideoPlayer play;
    public GameObject canvas;

    void Start()
    {
        videoPlayer.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D player)
    {

        if (player.gameObject.tag == "Player")
        {
            canvas.SetActive(true);
            play.Play();
            videoPlayer.SetActive(true);
            //Destroy(videoPlayer, timetoStop);
        }
    }
}