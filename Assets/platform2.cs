using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform2 : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {


        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

    }


    private void OncolllisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            if(transform.position.y<collision.transform.position.y-1.0f)
                collision.transform.SetParent(transform);
        }
        
    }
    private void OncolllisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}