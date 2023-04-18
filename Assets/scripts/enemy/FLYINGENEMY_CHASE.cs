using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLYINGENEMY_CHASE : MonoBehaviour
{
    public FlyingEnemy E;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            E.chase = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            E.chase = false;
        }
    }
}
