using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{


    public EnemyHealth Health;
    public GameObject player;
    public float damage;
    public Combat C;
    public float distanceBasic;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //Health= GetComponent<EnemyHealth>().health;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceBasic = Vector2.Distance(this.transform.position, player.transform.position);

        //Debug.Log(distance);
        if (distanceBasic < 4.5 && Input.GetKey(KeyCode.I))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (Input.GetKey(KeyCode.P)))
        {
            //Debug.Log(C.ReturnIsAttacking());
            //gameObject.GetComponent<EnemyHealth>().health -= damage;
            gameObject.SetActive(false);

            //if (Health.health < 0)
            {
                //Animator anim= gameObject.GetComponent<Animator>();
                //anim.SetTrigger("death");
                //Invoke("death", 1.5f);

                { Destroy(gameObject); }
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (Input.GetKey(KeyCode.I)))
        {

            gameObject.SetActive(false);
            //Debug.Log(C.ReturnIsAttacking());
            //gameObject.GetComponent<EnemyHealth>().health -= 1000.0f;

            //if (Health.health < 0)
            //{
            //    { Destroy(gameObject); }
            //}
            //{ Destroy(gameObject); }

        }
    }*/

    private void death()
    {
        gameObject.SetActive(false);

    }
}

