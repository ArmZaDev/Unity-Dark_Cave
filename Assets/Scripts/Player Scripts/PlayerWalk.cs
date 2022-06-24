using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 6f, jumpForce = 10;

    private Rigidbody2D myBody;

    private Vector3 tempPos;

    private PlayerAnimation playerAnim;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private Transform groundCheckPos;

    private BoxCollider2D boxCol2d;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();   
        boxCol2d = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        HandlePlayerAnimations();

        //HandleMovementWihtTransform();

        HandleJumping();
    }

    private void FixedUpdate()
    {
        HandleMovementWihtRigidBody();
    }

    void HandleMovementWihtTransform()
    {

        tempPos = transform.position;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            tempPos.x -= moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            tempPos.x += moveSpeed * Time.deltaTime;
        }

        transform.position = tempPos;

    }

    void HandleMovementWihtRigidBody()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);

            //myBody.AddForce(new Vector2(moveSpeed, 0f), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);

            //myBody.AddForce(new Vector2(moveSpeed, 0f), ForceMode2D.Impulse);
        }
        else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }
    }

    void HandlePlayerAnimations()
    {
        playerAnim.Play_WalkAnimation((int)Mathf.Abs(myBody.velocity.x));

        playerAnim.SetFacingDirection((int)myBody.velocity.x);

        playerAnim.Play_JumpAnimation(!IsGrounded());
    }

    bool IsGrounded()
    {
        //Debug.DrawRay(groundCheckPos.position, Vector2.down * 0.1f, Color.red);

        //return Physics2D.Raycast(groundCheckPos.position, Vector2.down, 0.1f, grondLayer);

        return Physics2D.BoxCast(boxCol2d.bounds.center,
            boxCol2d.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }

    void HandleJumping()
    {
        if (Input.GetButtonDown(TagManager.JUMP_BUTTON))
        {
            if (IsGrounded())
            {
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
            }
        }
    }

}// class







