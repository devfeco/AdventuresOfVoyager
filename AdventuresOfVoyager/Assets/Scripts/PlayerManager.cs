using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpSpeed ;
    private Rigidbody2D rigidbody2d;
    private float moveDirection;
    [SerializeField]
    private Animator animator;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator.SetFloat("Speed" , Mathf.Abs(moveDirection));
        rigidbody2d.velocity = new Vector2(moveSpeed * moveDirection, rigidbody2d.velocity.y);
        if (Mathf.Approximately(rigidbody2d.velocity.y, 0) && animator.GetBool("isJumping"))
        {
            animator.SetBool("isJumping", false);
        }
    }

    public void moveForward()
    {
        moveDirection = 1;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
    }
    public void moveBack()
    {
        moveDirection = -1;
        transform.rotation = Quaternion.Euler(new Vector3(0, 180f, 0));
    }
    public void Idle()
    {
        //animator.SetBool("isAttacking", false);
        moveDirection = 0;
    }
    public void Jump()
    {
        if (Mathf.Approximately(rigidbody2d.velocity.y , 0))
        {
            rigidbody2d.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
    }
    public void Attack()
    {
        //animator.SetBool("isAttacking" , true);
    }
}
