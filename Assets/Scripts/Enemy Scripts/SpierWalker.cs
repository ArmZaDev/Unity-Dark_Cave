using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpierWalker : MonoBehaviour
{
    private SpriteRenderer spriteRen;

    private Transform groundCheckPos;

    [SerializeField]
    private LayerMask groundLayer;

    private RaycastHit2D groundHit;

    [SerializeField]
    private float moveSpeed = 5f;

    private bool moveLeft;

    private Vector3 tempPos;
    private Vector3 tempScale;

    private float scaleXValue;

    private void Awake()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        groundCheckPos = transform.GetChild(0);

        moveLeft = Random.Range(0, 2) > 0 ? true : false;

        scaleXValue = transform.localScale.x;
    }

    private void Update()
    {
        HandleWalkingWithGroundCheck();
        CheckForGround();
    }

    void CheckForGround()
    {
        groundHit = Physics2D.Raycast(groundCheckPos.position,
            Vector2.down, 0.1f, groundLayer);

        if (!groundHit)
            moveLeft = !moveLeft;

    }

    void HandleWalkingWithGroundCheck()
    {
        tempPos = transform.position;
        tempScale = transform.localScale;

        //spriteRen.flipX = moveLeft;

        if (moveLeft)
        {
            tempPos.x -= moveSpeed * Time.deltaTime;
            tempScale.x = -scaleXValue;
        }
        else
        {
            tempPos.x += moveSpeed * Time.deltaTime;
            tempScale.x = scaleXValue;
        }

        transform.position = tempPos;
        transform.localScale = tempScale;
    }




}//class




