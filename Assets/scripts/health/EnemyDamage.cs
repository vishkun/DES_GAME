using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    
        public EnemyHealth Health;
        public float damage;
        public Combat C;
        // Start is called before the first frame update
        void Start()
        {
          //Health= GetComponent<EnemyHealth>().health;
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(C.isAttacking);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")&&(Input.GetKey(KeyCode.LeftControl)))
            {
                //Debug.Log(C.ReturnIsAttacking());
                gameObject.GetComponent<EnemyHealth>().health -= damage;

            if (Health.health < 0)
            {
                { Destroy(gameObject); }
            }
            }
        }
}

