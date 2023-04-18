using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            //iframes
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                
                //GetComponent<PlayerMovement>().enabled = false;
                //dead = true;

                //Player
                if(GetComponent<PlayerMovement>()!=null)
                    GetComponent<PlayerMovement>().enabled= false;

                //Enemy
                if(GetComponentInParent<EnemyPatrol>()!=null)
                    GetComponentInParent<EnemyPatrol>().enabled= false; 

                if(GetComponent<MeleeEnemy>()!= null)
                GetComponent<MeleeEnemy>().enabled= false;

                dead= false;
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}