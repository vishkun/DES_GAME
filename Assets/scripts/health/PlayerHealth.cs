using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthbar;
    private GameObject player;
    private Animator anim;
    [SerializeField] public GameObject endscreen;

    
    //public ui_change u;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth= health;
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*healthbar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);*/
        //u.change();

        //if(health)
        if(player.gameObject.GetComponent<PlayerHealth>().health < 0)
        {

            //anim.SetTrigger("die");

            gameObject.SetActive(false);
               

        }
    }
    
}
