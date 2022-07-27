using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField]
    private float jumpSpeed = 15;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Animator animator;
    private float moveDirection;
    private Rigidbody2D rigidbody2d;
    private void Start()
    {
        rigidbody2d = player.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        animator.SetFloat("Speed" , Mathf.Abs(moveDirection));
        rigidbody2d.velocity = new Vector2(moveSpeed * moveDirection , rigidbody2d.velocity.y);
    }


    public void moveForward()
    {
        moveDirection = 1;
        player.transform.rotation = Quaternion.Euler(0,0,0);
    }
    public void moveBack()
    {
        player.transform.rotation = Quaternion.Euler(0, 180, 0);
        moveDirection = -1;
    }
    public void Idle()
    {
        moveDirection = 0;
    }
    public void Jump()
    {
        if (Mathf.Approximately(rigidbody2d.velocity.y,0))
            rigidbody2d.AddForce(Vector3.up * jumpSpeed , ForceMode2D.Impulse);
    }
    public void Attack()
    {
        Debug.Log("Attacked");
    }

    
}
