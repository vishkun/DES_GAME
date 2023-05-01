using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoTest : MonoBehaviour
{
    // Start is called before the first frame update

    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.Stop(); // Stop the video on start
    }

    void Update()
    {
        // Check the keyCount from another script
        if (all_keys.keyCount == 3)
        {
            videoPlayer.Play(); // Play the video

            Time.timeScale = 0f;

        }
    }
}

