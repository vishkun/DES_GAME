using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class all_keys : MonoBehaviour
{
    public GameObject door;

    public Sprite key1,key2,key3;
    public Image key_collect1, key_collect2, key_collect3;

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
                key_collect1.sprite = key1;
            }
            if (keyCount == 2)
            {
                door.GetComponent<SpriteRenderer>().sprite = door_sprite;
                key_collect2.sprite = key2;
            }
            if (keyCount == 3)
            {
                door.GetComponent<SpriteRenderer>().sprite = door_sprite;
                key_collect3.sprite = key3;
            }
        }

        
    }
}
