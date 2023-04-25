using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public GameObject door;
    public int keyCount = 0;
    public Sprite door_sprite;

    //public AudioSource audioSource;
    //public AudioClip soundClip;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            door.GetComponent<BoxCollider2D>().enabled = false;

            this.gameObject.SetActive(false);
            //audioSource.PlayOneShot(soundClip);
            keyCount++;
        }
    }
}
