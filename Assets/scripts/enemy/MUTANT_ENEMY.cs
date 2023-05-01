using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUTANT_ENEMY : MonoBehaviour
{
    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float range;
    [SerializeField] private LayerMask playerLayer;

    public new_patrol Pat;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;
    public float damage;

    private Animator animp;
    private GameObject player;
    public PlayerHealth P;

    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        //enemyPatrol = GetComponentInParent<EnemyPatrol>();
        player = GameObject.FindGameObjectWithTag("Player");
        animp = player.GetComponent<Animator>();
        //this.GetComponent<new_patrol>().enabled = false;
        anim.SetBool("moving", false);
    }

    private void Update()
    {
        if (PlayerInSight())
        {

            anim.SetTrigger("contact");
            anim.SetBool("IsContact", true);
            //this.GetComponent<new_patrol>().enabled = true;

        }
        else
        {
            anim.SetBool("IsContact", false);
            anim.SetBool("moving", false);
            

        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        anim.SetBool("IsContact", true);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        anim.SetBool("IsContact", false);
    //    }
    //}

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        //if (hit.collider != null)
        //    playerHealth = hit.transform.GetComponent<health>();

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction * -1,
            initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }

    private void DamagePlayer()
    {
        if (PlayerInSight() /*&& attack*/)
        {
            animp.SetTrigger("hurt");
            P.health = (P.health) - (damage);
        }
    }
}
