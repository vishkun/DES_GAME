using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private Vector3 RespawnPoint;
    public GameObject fallDetector;

    [SerializeField] private float Glide_timeRemaining;



    [SerializeField]
    private float glidingSpeed;
    private float _initialGravityScale;

    private void Awake()
    {
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _initialGravityScale=body.gravityScale;
        RespawnPoint=transform.position;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        //sets animation parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

        
        if ((body.velocity.y <= 0) && (Input.GetKey(KeyCode.Space)))//after falling down and canJump is true
        {
            
            if (Glide_timeRemaining > 0.0)
            {
               

                body.gravityScale = 0;
                body.velocity = new Vector2(body.velocity.x, -glidingSpeed);
                body.gravityScale = 0.4f;   //badda hi haggu fix bruh theek krliyo isse lmfao
                Glide_timeRemaining -= Time.deltaTime;


            }
            
            //Debug.Log(Glide_timeRemaining);
        }

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

       
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;

        //if ( body.velocity.y <= 0)//after falling down and canJump is true
        //{
        //    body.gravityScale = 0;
        //    body.velocity = new Vector2(body.velocity.x, -glidingSpeed);
        //    body.gravityScale = 0.9f;   //badda hi haggu fix bruh theek krliyo isse lmfao
        //}

        


    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = RespawnPoint;
        }
        else if (collision.tag == "CheckPoint")
        {
            RespawnPoint = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)


    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
            Glide_timeRemaining=0.6f;
            body.gravityScale = _initialGravityScale;

        }

        
    }

   
}