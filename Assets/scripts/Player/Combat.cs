using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private AudioClip AttackSound; 

    private bool gotInput, isAttacking, isFirstAttack;

    private float lastInputTime = Mathf.NegativeInfinity;  //records the last time we attempted to attack 

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
    }
    private void Update()
    {
        checkCombatInput();
        checkAttack();
        SpecialAttack();
    }

    private void checkCombatInput()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (combatEnabled)
            {
                gotInput = true;
                lastInputTime = Time.time;
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
                anim.SetBool("isAttacking", isAttacking);

                

            }
        }

        if (Time.time >= lastInputTime + inputTimer)
        {
            //wait for new input 
            gotInput = false;
        }
        SoundManager.instance.PlaySound(AttackSound);
    }

    private void SpecialAttack()
    {
        if (Input.GetKey(KeyCode.P))
        {
            anim.SetBool("SpecialAttack", true);
        }
        //if (Time.time >= lastInputTime + inputTimer)
        //{
        //    //wait for new input 
        
        //}

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
}
