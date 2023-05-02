using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    
        public EnemyHealth Health;
        public GameObject player;
        public float damage;
        public Combat C;
        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        //Health= GetComponent<EnemyHealth>().health;
        }

        // Update is called once per frame
        void Update()
        {
            float distance = Vector2.Distance(this.transform.position, player.transform.position);
            
            Debug.Log(distance);
        if (distance<6&&Input.GetKey(KeyCode.P))
        {
            //Destroy(gameObject);
            Destroy(gameObject, 1.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")&&(Input.GetKey(KeyCode.I)))
            {
                //Debug.Log(C.ReturnIsAttacking());
                gameObject.GetComponent<EnemyHealth>().health -= damage;

                if (Health.health < 0)
                {
                    { Destroy(gameObject); }
                }
            }
            
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (Input.GetKey(KeyCode.P)))
        {

            Destroy(gameObject);
            //Debug.Log(C.ReturnIsAttacking());
            //gameObject.GetComponent<EnemyHealth>().health -= 1000.0f;

            //if (Health.health < 0)
            //{
            //    { Destroy(gameObject); }
            //}
            //{ Destroy(gameObject); }

        }
    }


}

