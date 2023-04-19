using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    
        public EnemyHealth Health;
        public float damage;
        // Start is called before the first frame update
        void Start()
        {
          //Health= GetComponent<EnemyHealth>().health;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
              gameObject.GetComponent<EnemyHealth>().health -= 50;

            if (Health.health < 0)
            {
                { Destroy(gameObject); }
            }
            }
        }
}

