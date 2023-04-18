using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform posA, posB, Player;
    public int Speed;
    Vector2 targetPos;
    Vector3 sc;

    

    // Start is called before the first frame update
    void Start()
    {
        targetPos = posB.position;
        sc = Player.transform.localScale;

        //float width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f) targetPos = posB.position;

        if (Vector2.Distance(transform.position, posB.position) < .1f) targetPos = posA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        collision.transform.SetParent(transform);
    //        //collision.gameObject.transform.localScale = Vector3.one;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    {
    //        if (collision.CompareTag("Player"))
    //        {
    //            collision.transform.SetParent(null);
    //        }
    //    }

    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
            // collision.gameObject.transform.localScale = sc;
            //gameObject.transform.localScale += new Vector3.one
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

}

