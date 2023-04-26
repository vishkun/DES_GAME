using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class all_keys : MonoBehaviour
{
    public GameObject door;
    public GameObject key;
    public int keyCount = 0;
    public Sprite door_sprite, ui;
    public bool collide;
    public key_sprite k;
    

    public AudioSource audioSource;
    public AudioClip soundClip;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            door.GetComponent<BoxCollider2D>().enabled = false;

            audioSource.PlayOneShot(soundClip);
            keyCount++;

            collide = true;

            if (keyCount == 1)
            {
                door.GetComponent<SpriteRenderer>().sprite = door_sprite;
                key.GetComponent<SpriteRenderer>().sprite = ui;
            }
            if (keyCount == 2)
            {
                door.GetComponent<SpriteRenderer>().sprite = door_sprite;
                key.GetComponent<SpriteRenderer>().sprite = ui;
            }
            if (keyCount == 3)
            {
                door.GetComponent<SpriteRenderer>().sprite = door_sprite;
                key.GetComponent<SpriteRenderer>().sprite = ui;
            }
        }
    }
}
