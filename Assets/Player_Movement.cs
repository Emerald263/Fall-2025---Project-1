using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine.SceneManagement; //importing SceneManagement Library
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Scripts Ref:")]
    public Hookshot Hook;

    //Movement Variables
    Rigidbody2D rb;
    public float jumpForce;
    public float speed;
    public float dash;
 
    //Ground check
    public bool isGrounded;

    //Animation variables
    Animator anim;
    public bool moving_right;
    public bool moving_left;
    public bool dash_right;
    public bool dash_left;
    public bool attack;
    public bool jump;


    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
  
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        //variables to mirror the player
        Vector3 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x); //take absolute value of the current x scale, this is always positive


        rb.velocity = new Vector2(rb.velocity.x * 5f, rb.velocity.y);

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= speed;
         
            //is moving
            moving_left = true;
            attack = false;
            Debug.Log("move left");

        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += speed;
        
            //is moving
            moving_right = true;
            attack = false;
            Debug.Log("move right");
        }

        if (Input.GetKey("a") && Input.GetKey(KeyCode.LeftShift))
        {
            newPosition.x -= speed + dash;

            //is dashing
            dash_left = true;
            attack = false;
            Debug.Log("dash");

        }

        if (Input.GetKey("d") && Input.GetKey(KeyCode.LeftShift))
        {
            newPosition.x += speed + dash;
   
            //is dashing
            dash_right = true;
            attack = false;
            Debug.Log("dash");
        }


        if (Input.GetKey("space") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump = true;
            attack = false;
            moving_right = false;
            moving_left = false;
            Debug.Log("jump");
        }


     if (Input.GetKeyUp("a") && (Input.GetKeyUp("d")))
        {
            moving_right = false;
            moving_left = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Grappling
            moving_right = false;
            moving_left = false;
            Debug.Log("grapple");
        }

        anim.SetBool("Move_right", moving_right);
        anim.SetBool("Move_left", moving_left);
        anim.SetBool("Jumping", jump);
        anim.SetBool("Attack1", attack);

        transform.position = newPosition;
        transform.localScale = newScale;

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Debug.Log("i hit the ground");
         
            isGrounded = true;
           
        }

    

        if (collision.gameObject.tag.Equals("death"))
        {
            Debug.Log("death");
            SceneManager.LoadScene(1);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = false;
            Debug.Log("not grounded");

        }

    }
}

