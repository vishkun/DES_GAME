using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key3 : MonoBehaviour
{
    public GameObject door;
    public int keyCount = 0;
    public Sprite door_sprite,ui;
    public bool collide;
    public key_sprite k;

    private void OnTriggerEnter2D(Collider2D col)
    {
        //if(col.CompareTag("Player"))
        if (col.gameObject.tag == "Player")
        {
            door.GetComponent<BoxCollider2D>().enabled = false;

            this.gameObject.SetActive(false);
            keyCount++;

            collide = true;

            //if (keyCount == 0)
            //{
            //    door.GetComponent<SpriteRenderer>().sprite = door1;
            //}
            if (keyCount == 1)
            {
                door.GetComponent<SpriteRenderer>().sprite = door_sprite;
                k.key.GetComponent<SpriteRenderer>().sprite = ui;
            }
            //if (keyCount == 2)
            //{
            //    door.GetComponent<SpriteRenderer>().sprite = door2;
            //}
            //if (keyCount == 3)
            //{
            //    door.GetComponent<SpriteRenderer>().sprite = door3;
            //}

        }
    }
}
