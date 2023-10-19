using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    private float movementInput;
    public string left;
    public string right;
    public string up;
    private Rigidbody2D playerRBY;
    private Rigidbody2D playerRBX;
    private bool facingLeft;
    private bool facingRight;
    private bool isGrounded;
    private bool contactWithRightSide;
    public Transform feetPosition;
    public Transform rightPosition;
    public float checkRadius;
    public LayerMask groundMask;
    public LayerMask playerMask;
    private bool onPlayer;
    public Animator animator;

    void Start() {
        playerRBY = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (Input.GetKey(right)) {
            movementInput = 1;
            facingRight = true;
        } else if (Input.GetKey(left)) {
            movementInput = -1;
            facingLeft = true;
        } else {
            movementInput = 0;
        }
        animator.SetFloat("Movement", Mathf.Abs(movementInput));

        flipSprite();
        Vector3 previousRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, previousRotation.y, 0f);
        playerRBY.velocity = new Vector2(movementInput * playerSpeed, playerRBY.velocity.y);
        playerRBX.velocity = new Vector2( playerRBX.velocity.x, movementInput * playerSpeed);
    }

    void Update() {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, groundMask);
        contactWithRightSide = Physics2D.OverlapCircle(rightPosition.position, checkRadius, groundMask);
        onPlayer = Physics2D.OverlapCircle(feetPosition.position, checkRadius, playerMask);

        if ((isGrounded || onPlayer) && Input.GetKey(up)) {
            animator.SetBool("isJumping",true);
            playerRBY.velocity = Vector2.up * jumpForce;
        }
        else if ((contactWithRightSide || onPlayer) && Input.GetKey(up)) {
            animator.SetBool("isJumping", true);
            playerRBY.velocity = (Vector2.up * jumpForce);
            playerRBX.velocity = (Vector2.left * jumpForce);
        }
        else if ((isGrounded || onPlayer) && !Input.GetKey(up)) {
            animator.SetBool("isJumping",false);
        }

    }

    void flipSprite() {
        if (movementInput < 0 && facingRight){
            transform.Rotate(0f, 180f, 0f);
            facingRight = false;
        } else if (movementInput > 0 && facingLeft){
            transform.Rotate(0f, 180f, 0f);
            facingLeft = false;
        }
    }

}
