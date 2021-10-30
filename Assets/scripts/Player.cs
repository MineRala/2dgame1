using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

    public class Player : MonoBehaviour
{
    public float movementSpeed = 40f;
    public FixedJoystick joystick;
    public float horizontalMove = 0f;
    Rigidbody2D rb;
    public bool isGrounded = false;
    public bool isColumnJump = false;
    private Animator anim;
    public float movement = 1f;
    public float jumpVelocity = 5f;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void FixedUpdate() 
    {

       // horizontalMove = joystick.Horizontal * movementSpeed;

        if (joystick.Horizontal >= .2f)
        {
            horizontalMove = movementSpeed;
            anim.SetBool("isRunning", true);
            mobileMove(1f);
        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = movementSpeed;
            anim.SetBool("isRunning", false);
            mobileMove(-1f);
        }
        else
        {
            horizontalMove = 0f;
            anim.SetBool("isRunning", false);

        }

        float verticalMove = joystick.Vertical;

        if (verticalMove >= .5f)
        {

        }

        /* int i = 0 ;

        while (i < Input.touchCount)
        {
            if(Input.GetTouch (i).position.x > Screen.width / 2){
                mobileMove(1f);
            }

            if(Input.GetTouch (i).position.x < Screen.width / 2){
                mobileMove(-1f);
               anim.SetBool("isRunning", false);

            }
            ++i;
        }   */
    }

    private void mobileMove(float horizontalInput)
    {
        if(horizontalInput> 0)
        {
            anim.SetBool("isRunning", true);

        }
        else if (horizontalInput<0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        Vector2 velocity =rb.velocity;
        velocity.x = horizontalInput*movementSpeed; 
        rb.velocity =velocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }

        if (other.gameObject.CompareTag("column"))
        {
            isColumnJump = false;
            
        }
        Debug.Log("carpti: " + other.collider.name);
    }

    public void JumpButtonClicked()
    {
        if (isGrounded && rb.velocity.y <= 0)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            isColumnJump = true;
            isGrounded = false;
        }
    }
    
}
