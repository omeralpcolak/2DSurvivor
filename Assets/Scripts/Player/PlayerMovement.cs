using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;
    [SerializeField] float playerMovementSpeed;
    [HideInInspector] public bool playerFacingRight;
    public bool canItMove;
    private bool isHitted;
    

    private void Start() 
    {
        rbody = GetComponent<Rigidbody2D>();
        anim =  GetComponent<Animator>();
        canItMove = true;
        isHitted = false;
    }

    
    private void FixedUpdate() 
    {   
        if (canItMove)
        {
            MovePlayer();
        }
        else 
        {
            StopMovement();
        }
        
    }

    public void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        rbody.velocity = new Vector2 (horizontalInput*playerMovementSpeed,rbody.velocity.y);
        if (rbody.velocity.x > 0 && playerFacingRight)
        {
            Flip();
        }
        if (rbody.velocity.x < 0 && !playerFacingRight)
        {
            Flip();
        }
        anim.SetFloat("movementSpeed",Mathf.Abs(rbody.velocity.x));
    }

    public void Flip()
    {
        transform.Rotate (0f,180f,0f);
        playerFacingRight = !playerFacingRight;
    }

    public void StopMovement()
    {
        rbody.velocity = new Vector2 (0f,0f);
    }

    public IEnumerator HitAnimation()
    {
        yield return null;
        isHitted = true;
        anim.SetBool("isHitted", isHitted);
        yield return new WaitForSeconds(.22f);
        isHitted = false;
        anim.SetBool("isHitted", isHitted);
    }
}
