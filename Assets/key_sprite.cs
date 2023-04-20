using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_sprite : MonoBehaviour
{
    public key3 k;
    public GameObject key;
    //public int keyCount = 0;
    public Sprite sprite,sprite1;

    // Start is called before the first frame update

    void Start()
    {
        key.GetComponent<SpriteRenderer>().sprite = sprite;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //if(col.CompareTag("Player"))
        if (k.collide)
        {
            //key.GetComponent<SpriteRenderer>().sprite = sprite;
            key.GetComponent<SpriteRenderer>().sprite = sprite1;
        }
    }
}
