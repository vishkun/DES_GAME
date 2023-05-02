using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class special_attack : MonoBehaviour
{
    public PlayerMovement move;
    //public PlayerMovement move;
    public GameObject player;
    public Animator animp;
    public Bealzebuddy_Cooldown C;
    bool p;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animp = player.GetComponent<Animator>();

        move = player.GetComponent<PlayerMovement>();
        GameObject canvas = GameObject.Find("bealzebuddyIcon");
        C = canvas.GetComponent<Bealzebuddy_Cooldown>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            p = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        {


            //Debug.Log(collision.gameObject.tag);
            if (collision.gameObject.CompareTag("enemy") && (Input.GetKeyDown(KeyCode.P)))
            { Destroy(collision.gameObject); }
        }

    }
}

