using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;
    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;
    [SerializeField]
    private Transform attack1HitBoxPos;
    [SerializeField]
    private LayerMask whatIsDamagable;
    private Animator anim;

    [SerializeField] private AudioClip[] AttackSounds;
    public AudioSource audioSource;
    public AudioListener audioListener;

    
    private bool /*gotInput,*/ isAttacking, isFirstAttack;
    public bool gotInput;
    public Bealzebuddy_Cooldown B;

    private float lastInputTime = Mathf.NegativeInfinity;  //records the last time we attempted to attack 

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);

        audioListener = GetComponent<AudioListener>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        checkCombatInput();
        checkAttack();
        SpecialAttack();
    }

    private void checkCombatInput()
    {
        if (Input.GetKey(KeyCode.I))
        {
            if (combatEnabled)
            {
                gotInput = true;
                lastInputTime = Time.time;
                PlayAttackSound();
            }
        }
    }

    private void checkAttack()  //making attack happen when input occurs
    {
        if (gotInput)
        {
            //perform attack 1
            
            if (!isAttacking)//while not in attack animation 
            {

                gotInput = false;
                isAttacking = true;
                isFirstAttack = !isFirstAttack;  //used to alternate b/w the 2 attack animations

                anim.SetBool("attack1", true);
                anim.SetBool("firstAttack", isFirstAttack);
                PlayAttackSound();
                anim.SetBool("isAttacking", isAttacking);
            }
        }

        if (Time.time >= lastInputTime + inputTimer)
        {
            //wait for new input 
            gotInput = false;
        }
    }

   private void PlayAttackSound()
    {
        audioSource.clip = AttackSounds[Random.Range(0, AttackSounds.Length)];
        audioSource.Play();

        /*float randomNumber = Random.Range(1f, 3f);
        
        if (randomNumber == 1)
        {
            SoundManager.instance.PlaySound(AttackSound1);
        }
        else if (randomNumber == 2)
        {
            SoundManager.instance.PlaySound(AttackSound2);
        }
        else if (randomNumber == 3)
        {
            SoundManager.instance.PlaySound(AttackSound3);
        }*/

    }
    private void SpecialAttack()
    {
       //GameObject player= GameObject.FindGameObjectWithTag("Player");
       // Collider2D col = player.GetComponent<Collider2D>();
        

    }
    private void FinishSpecialAttack()//will gwt called at the end of attack animation 
    {
        
        anim.SetBool("SpecialAttack", false);
    }
    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, whatIsDamagable);

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("damage", attack1Damage);  //Calls the method named damage on every MonoBehaviour in this game object.

            //Instantiate hit particle
        }
    }

    private void FinishAttack1()//will gwt called at the end of attack animation 
    {
        isAttacking = false;
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("attack1", false);
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
    }

    public bool ReturnIsAttacking()
    {
        return gotInput;
    }

    
}
