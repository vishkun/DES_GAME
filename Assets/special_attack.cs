using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class special_attack : MonoBehaviour
{
    //public Bealzebuddy_Cooldown C;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        while (Input.GetKey(KeyCode.P))
        {
            if (collision.gameObject.tag == "enemy")
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
}
