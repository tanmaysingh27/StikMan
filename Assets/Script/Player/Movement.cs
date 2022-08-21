using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class  Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    public float HorizontalInput;
    private bool Running;
    private float wallJumpCooldown;
    [SerializeField] private float speed;
    [SerializeField] private float JumpForce;
    [SerializeField]private LayerMask ground;
    [SerializeField]private LayerMask platform;
    [SerializeField]private LayerMask wall;
    
    
    private void Awake()
    {   
        //Grab Reference
        body  = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }
    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(HorizontalInput * speed,body.velocity.y);
              

        //Fliping of Player

        if(HorizontalInput > 0f)
            body.transform.localScale = Vector3.one;
        else if (HorizontalInput < 0f)
            body.transform.localScale =  new Vector3(-1,1,1);


    // jumping                        
        if(Input.GetKey(KeyCode.Space) && isGrounded())
             jump();
        
            
        
        // Debug.Log(onWall());

        

        //Animation 
        anim.SetBool("running", HorizontalInput !=0);
        anim.SetBool("grounded", isGrounded());
        
       


    }

    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, JumpForce);
        anim.SetTrigger("jump");
        
    }
    private bool isOnPlatform()
    {
        RaycastHit2D raycasthit2d =  Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size, 0f, Vector2.down, 0.1f, platform);
        return raycasthit2d.collider != null ;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycasthit2d =  Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size, 0f, Vector2.down, 0.1f, ground);
        return raycasthit2d.collider != null ;
    }

    private bool onWall()
    {
        RaycastHit2D raycasthit2d =  Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size, 0f, new Vector2(transform.localScale.x, 0), 0.1f, wall);

        return raycasthit2d.collider != null ;
    }

    public bool canAttack (){
        return HorizontalInput == 0 && isGrounded();
    }
    
     
          
        
}
