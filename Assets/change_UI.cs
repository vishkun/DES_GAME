using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_UI : MonoBehaviour
{
    public PlayerHealth p;
    public Image image;
    public Sprite s1,s2,s3,s4,s5;
    
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
        if(p.health>75&&p.health<100)
        {
            image.sprite = s1;
        }
        else if(p.health<75 && p.health > 50) 
        {
            image.sprite = s2;
            //Debug.Log(p.health);
        }
        else if(p.health < 50&& p.health>25)
        {
            image.sprite = s3;
        }
        else if (p.health < 25&&p.health>1)
        {
            image.sprite = s4;
        }
        else if(p.health<1)
        {
            image.sprite = s5;
        }
    }
}
