using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class all_keys : MonoBehaviour
{
    //public GameObject door;
    //public GameObject key;

    public static int keyCount = 0;

    public Sprite door_sprite, ui;
    //public bool collide;
    //public Sprite k1,k2,k3;
    public Image image1, image2, image3;
    

    public AudioSource audioSource;
    public AudioClip soundClip;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //door.GetComponent<BoxCollider2D>().enabled = false;

            audioSource.PlayOneShot(soundClip);

            keyCount++;

            Debug.Log("keyCount = " + all_keys.keyCount);


            this.gameObject.SetActive(false);

            //collide = true;

            if (keyCount == 1)
            {
                //door.GetComponent<SpriteRenderer>().sprite = door_sprite;
                //keyCount++;
                image1.sprite = ui;
                
            }
            if (keyCount == 2)
            {
                //door.GetComponent<SpriteRenderer>().sprite = door_sprite;
                //keyCount++;
                image2.sprite = ui;

            }
            if (keyCount == 3)
            {
                //door.GetComponent<SpriteRenderer>().sprite = door_sprite;
                //keyCount++;
                image3.sprite = ui;
            }
        }
    }
}