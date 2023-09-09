using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc_for_ground;
 

    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask jumpableWall;


    private bool isUpsideDown=false;  


    private float HorizontalPlayerDirection=0f;
    private SpriteRenderer sr;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private int groundJumps=1;
    private int wallJumps = 1;

    private int maxGroundJumps = 1;
    private int maxWallJumps = 1;

    // bool isInAir=false;

    // double jumping
    [SerializeField] private float doubleJumpForce = 18f;
    private bool isDoubleJump=false;


    private float boxColliderBorders = 0.2437153f;
    // object from pause menu to stop player from any movement
    PauseMenu pauseMenu;
    private enum MovementState
    {
        idle, running, jumping, falling, doubleJump, wallJump
    }

    [SerializeField] private AudioSource jumpSoundEffect;
   
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc_for_ground= GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sr= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
   private void Update()
    {
        HorizontalPlayerDirection = Input.GetAxisRaw("Horizontal");

        //Player Movement:
        //1.Jumping
        if (SceneManager.GetActiveScene().buildIndex > 2 && SceneManager.GetActiveScene().buildIndex <11 /*7*/)
        {
            maxGroundJumps = 2;

        }
        // for changing the direction of the gravity

        if (SceneManager.GetActiveScene().buildIndex ==7)
        {
            ChangeGravity();
        }


        if (Input.GetButtonDown("Jump"))
        {
            // to check if the player touch the celling and to change direction of jumping

            if (!isUpsideDown)
            {
                if (IsGrounded())
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    jumpSoundEffect.Play();
                   
                    // isInAir= true;
                }
                //2.Double Jump

                else if (!IsGrounded()/*&&isInAir*/&& groundJumps < maxGroundJumps)
                {
                    rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                    jumpSoundEffect.Play();
                    isDoubleJump = true;
                    groundJumps++;
                    //  isInAir= false;
                
                }
            }

            else
            {
                if (IsGrounded())
                {
                    rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
                    jumpSoundEffect.Play();

                    // isInAir= true;
                }
                //2.Double Jump

                else if (!IsGrounded()/*&&isInAir*/&& groundJumps < maxGroundJumps)
                {
                    rb.velocity = new Vector2(rb.velocity.x, -doubleJumpForce);
                    jumpSoundEffect.Play();
                    isDoubleJump = true;
                    groundJumps++;
                    //  isInAir= false;
                }
            }

        }
            //reset the jumps counter
        if(IsGrounded() )
        {
            groundJumps = 1;
            isDoubleJump= false;
        }




        // fliping the y direction of the player
        if (isUpsideDown)
        {
            sr.flipY= true;
            // boundries of the box collider
            bc_for_ground.offset = new Vector2(0f, boxColliderBorders);
        }
        else
        {

            sr.flipY= false;
            // boundries of the box collider
            bc_for_ground.offset = new Vector2(0f,-boxColliderBorders);
        }


        //2.Moving Left and Right
        rb.velocity = new Vector2(HorizontalPlayerDirection* moveSpeed, rb.velocity.y);


        //2.Changing Player State

          UpdateAnimationState();
       
       
     
    }



    private void UpdateAnimationState()
    {
        MovementState playerState;
        //conditions to check if running or not

        if (HorizontalPlayerDirection > 0f)
        {

            playerState = MovementState.running;
            sr.flipX = false;
        }
        else if (HorizontalPlayerDirection < 0f)
        {

            playerState = MovementState.running;
            sr.flipX = true;
        
        }
        else
        {
            playerState = MovementState.idle;
           // isDoubleJump= false;    
        }



        // conditions to check if jumping or falling
        if( rb.velocity.y>.1f)
        {
            playerState = MovementState.jumping;
            if(isDoubleJump)
            {
                playerState = MovementState.doubleJump;
            }
            
        }
        else if (rb.velocity.y < -.1f)
        {
            playerState = MovementState.falling;
            isDoubleJump= false;
            
        }
        

        anim.SetInteger("State",(int) playerState);
    }

   
    private  bool IsGrounded()
    {
        // the first two arguments is to make a box similar to the box collider to our player
        //third argument is for the rotation
        // boxcast to check if the player is overlaped


        // if condition to change the box cast direction from down to top and vise verse
        if (isUpsideDown)
        {
            return Physics2D.BoxCast(bc_for_ground.bounds.center, bc_for_ground.bounds.size, 0f, Vector2.up, .1f, jumpableGround);
        }
        else
        {
            return Physics2D.BoxCast(bc_for_ground.bounds.center, bc_for_ground.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        }
        
    }

    void ChangeGravity()
    {
        if (Input.GetKeyDown(KeyCode.G)&&IsGrounded())
        {

            rb.gravityScale *= -1;
            isUpsideDown = !isUpsideDown;
        }
    }
    







    // To Draw the Bounces
    //  private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawCube(bc_for_ground.bounds.center, bc_for_ground.bounds.size);
    //     Gizmos.color = Color.green;

    //  
    //    Gizmos.DrawCube(bc_for_wall_from_right.bounds.center, bc_for_wall_from_right.bounds.size);
    //   Gizmos.color = Color.green;

    //    Gizmos.DrawCube(bc_for_wall_from_left.bounds.center, bc_for_wall_from_left.bounds.size);

    // }

}
