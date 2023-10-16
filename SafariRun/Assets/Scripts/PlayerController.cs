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
    private Rigidbody2D playerRB;
    private bool facingLeft;
    private bool facingRight;
    private bool isGrounded;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask groundMask;
    public LayerMask playerMask;
    private bool onPlayer;
    public Animator animator;

    void Start() {
        playerRB = GetComponent<Rigidbody2D>();
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

        playerRB.velocity = new Vector2(movementInput * playerSpeed, playerRB.velocity.y);
    }

    void Update() {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, groundMask);
        onPlayer = Physics2D.OverlapCircle(feetPosition.position, checkRadius, playerMask);

        if ((isGrounded || onPlayer) && Input.GetKey(up)) {
            animator.SetBool("isJumping",true);
            playerRB.velocity = Vector2.up * jumpForce;
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
