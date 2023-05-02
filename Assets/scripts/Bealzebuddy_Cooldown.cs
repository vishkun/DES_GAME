using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bealzebuddy_Cooldown : MonoBehaviour
{
    [SerializeField]
    private Image fill_cooldown;
    [SerializeField]
    private TMP_Text text_cooldown;

    public bool isCooldown = false;
    private float cooldownTime = 10.0f;
    private float cooldownTimer = 0.0f;
    private GameObject player;
    private Animator animp;
    private PlayerMovement move;


    public AudioSource audioSource; 
    public AudioClip soundClip; 

    // Start is called before the first frame update
    void Start()
    {
        text_cooldown.gameObject.SetActive(false);
        fill_cooldown.fillAmount = 10.0f;
        UseAbility();

        player = GameObject.FindGameObjectWithTag("Player");
        
        move= player.GetComponent<PlayerMovement>();

        animp = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!(isCooldown))
            {
                UseAbility();
                animp.SetBool("SpecialAttack", true);
                isCooldown = true;
                
            }
        }
        if(isCooldown)
        {
            ApplyCooldown();
        }
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime; 
        

        if(cooldownTimer < 0.0f)
        {
            isCooldown = false;
            text_cooldown.gameObject.SetActive(false);
            fill_cooldown.fillAmount = 0.0f;
        }
        else
        {
            text_cooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            fill_cooldown.fillAmount = cooldownTimer / cooldownTime;
        }
        if (fill_cooldown.fillAmount == 0.0f)
        {
            audioSource.PlayOneShot(soundClip);
        }
    }

    public void UseAbility()
    {
 

        if (isCooldown)
        {
            //return false;
        }
        else
        {
            //move.P = false;
            isCooldown = true;
            text_cooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
            
            //return true;
        }
    }
}
