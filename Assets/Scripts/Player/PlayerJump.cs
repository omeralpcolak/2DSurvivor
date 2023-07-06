using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rbody;
    [SerializeField] float jumpPower;
    //[SerializeField] float fallMultiplier;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    Vector2 vecGravity;
    bool doubleJump;
    Animator anim;


    
    void Start()
    {   
        vecGravity = new Vector2 (0,-Physics2D.gravity.y);
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {   
        JumpFunc();
    }

    public void JumpFunc()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position,new Vector2(0.8f,0.3f), CapsuleDirection2D.Horizontal,0,groundLayer);

        if (isGrounded)
        {
            doubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if(isGrounded)
            {
                rbody.velocity = new Vector2 (rbody.velocity.x,jumpPower);
            }
            else
            {
                if(doubleJump)
                {
                    rbody.velocity = new Vector2 (rbody.velocity.x,jumpPower*0.8f);
                    doubleJump = false;
                }
            }
        }

        anim.SetBool("isItOnGround",isGrounded);
    }
}
