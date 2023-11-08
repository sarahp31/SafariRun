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
    private bool contactWithRightSide;
    public Transform feetPosition;
    public Transform rightPosition;
    public float checkRadius;
    public LayerMask groundMask;
    public LayerMask playerMask;
    private bool onPlayer;
    public Animator animator;
    public AudioClip soundJump;
    private AudioSource audioSource;

    //Mobile
    public Joystick joystick;

    void Start() {
        playerRB = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate() {
        if (Input.GetKey(right)) {
            movementInput = 1;
            facingRight = true;
        } else if (Input.GetKey(left)) {
            movementInput = -1;
            facingLeft = true;
        } else if (joystick.Horizontal > 0.3f) {
            movementInput = 1;
            facingRight = true;
        } else if (joystick.Horizontal < -0.3f) {
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
        contactWithRightSide = Physics2D.OverlapCircle(rightPosition.position, checkRadius, groundMask);
        onPlayer = Physics2D.OverlapCircle(feetPosition.position, checkRadius, playerMask);

        if ((isGrounded || onPlayer) && (Input.GetKey(up) || joystick.Vertical > 0.3f)) {
            animator.SetBool("isJumping",true);
            playerRB.velocity = Vector2.up * jumpForce;
            audioSource.PlayOneShot(soundJump);
        }
        // else if ((contactWithRightSide || onPlayer) && Input.GetKey(up)) {
        //     animator.SetBool("isJumping", true);
        //     playerRB.velocity = Vector2.up * jumpForce;
        //     contactWithRightSide =  false;
        // }
        else if ((isGrounded || onPlayer) && !(Input.GetKey(up) || joystick.Vertical > 0.3f)) {
            animator.SetBool("isJumping",false);
        }

    }

    void flipSprite() {
        if (movementInput < 0 && facingRight){
            transform.Rotate(0f, 180f, 0f);
            facingRight = !facingRight;
        } else if (movementInput > 0 && facingLeft){
            transform.Rotate(0f, 180f, 0f);
            facingLeft = !facingLeft;
        }
    }

}
