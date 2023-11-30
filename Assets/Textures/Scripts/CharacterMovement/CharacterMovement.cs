using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator animator;
    public float velocity;
    private Rigidbody2D rb;
    private float moveX;
    private float moveY;
    private bool canMove = true;
    
   
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (canMove)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
            if (Input.GetKeyDown(KeyCode.E))
            {
                moveX = 0; moveY = 0;
                canMove = false;
                StartCoroutine(Pick());

            }

            if (moveX != 0 || moveY != 0)
            {
                animator.SetFloat("moveX", moveX);
                animator.SetFloat("moveY", moveY);
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);

            }
        }
       

        



    }


    private void FixedUpdate()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        rb.velocity = new Vector2(moveX, moveY).normalized * velocity;
    }

    private IEnumerator Pick()
    {
        animator.SetBool("isPicking", true);
        yield return null;
        animator.SetBool("isPicking", false);
        yield return new WaitForSeconds(.5f);
        canMove = true;
    }
}
