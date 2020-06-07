using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    const string PLAYER_RUNNING = "isRunning";
    const string PLAYER_JUMPING = "isJumping";


    bool isAlive = true;

    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider2D;
    BoxCollider2D myFeetCollider2D;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        myFeetCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (isAlive)
        {
            Run();
            Jump();
            FlipDirection();

        }
    }
    private void Run()
    {
        float controlInput = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlInput * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool hasHorizontalMove = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool(PLAYER_RUNNING, hasHorizontalMove);
    }

    private void FlipDirection()
    {
        bool hasHorizontalMove = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (hasHorizontalMove)
        {

            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    private void Jump()
    {
        if (!myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myAnimator.SetBool(PLAYER_JUMPING, false);
            return;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocity;
            myAnimator.SetBool(PLAYER_JUMPING, true);
        }
    }
}
