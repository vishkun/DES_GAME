using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_UI : MonoBehaviour
{
    public PlayerHealth p;
    public Image image;
    public Sprite s1,s2,s3,s4,s5,s6,s7,s8,s9;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        change();
    }

    void change()
    {
        if(p.health == 9)
        {
            image.sprite = s1;
        }
        else if(p.health == 8) 
        {
            image.sprite = s2;
            //Debug.Log(p.health);
        }
        else if(p.health == 7)
        {
            image.sprite = s3;
        }
        else if (p.health == 6)
        {
            image.sprite = s4;
        }
        else if(p.health == 5)
        {
            image.sprite = s5;
        }


        else if (p.health == 4)
        {
            image.sprite = s6;
            //Debug.Log(p.health);
        }
        else if (p.health == 3)
        {
            image.sprite = s7;
        }
        else if (p.health == 2)
        {
            image.sprite = s8;
        }
        else if (p.health == 1)
        {
            image.sprite = s9;
        }
    }
}
