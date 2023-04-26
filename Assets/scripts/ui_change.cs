using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class ui_change : MonoBehaviour
{
    public GameObject ui;
    public SpriteRenderer s;
    public Sprite s1, s2, s3, s4;
    //public Canvas i;
    //public Image s1, s2, s3, s4;
    public PlayerHealth h;
    // Start is called before the first frame update
    void Start()
    {
        
        h= GetComponent<PlayerHealth>();
        s=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Image>().sprite
        //
    }

    public void change()
    {
        float cureent = h.health;
        if (cureent == 4)
        { ui.GetComponent<Image>().sprite = s1; }
        else if (cureent==3)
        { ui.GetComponent<Image>().sprite = s2; }
        else if (cureent==2)
        { ui.GetComponent<Image>().sprite = s3; }
        else if (cureent==1)
        { ui.GetComponent<Image>().sprite = s4; }

        Debug.Log("health = " + h.health);
    }
}
