using System;
using UnityEngine;

public class TL_JumpCharacter : MonoBehaviour
{
    public float JumpHeight;
    private float DistanceToGround;
    private Collider CharacterCollider;
    private Rigidbody CharacterRigidbody;
    private Animator CharacterAnimator;

    [SerializeField] private int _jumpCounter = 0;
    [SerializeField] private float landingCheckDistance = 2f;

    private bool readyToJump;
    [SerializeField] private bool isJumping;


    void Start()
    {
        //Obtain the collider and rigidbody
        CharacterCollider = GetComponent<Collider>();
        CharacterRigidbody = GetComponent<Rigidbody>();

        //Obtain the extents of the collider
        DistanceToGround = CharacterCollider.bounds.extents.y;

        CharacterAnimator = GetComponent<Animator>();
    }

    void Jump()
    {
        //If the player presses the jmup button and if the character is touching the ground
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Nested ifs because c# isn't short-ciruiting my conditional with the function inside the first if?
            // ~ Alex

            if(IsCharacterTouchingTheGround())
            {
                if(_jumpCounter == 0)
                {
                    _jumpCounter++;
                    readyToJump = true;
                    CharacterAnimator.SetTrigger("IsJumping");
                    isJumping = true;

                }

            }
        }
    }

    //Checks if the character is touching the ground or not
    public bool IsCharacterTouchingTheGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, CharacterCollider.bounds.extents.y + 0.1f, 3);
    }

    public int GetJumpCounter()
    {
        return _jumpCounter;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ResetJump();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ResetJump();
        }
    }

    public void ResetJump()
    {
        isJumping = false;
        _jumpCounter = 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        _jumpCounter++;
        isJumping = true;
    }

    void FixedUpdate()
    {
        if(readyToJump)
        {
            CharacterRigidbody.velocity = Vector3.zero;
            CharacterRigidbody.velocity = Vector3.up * JumpHeight;
            readyToJump = false;
        }
    }

    private void Update()
    {
        if (IsCharacterTouchingTheGround())
        {
            _jumpCounter = 0;
        }
        if (CharacterRigidbody.velocity.y < -3.5)
        {
            CharacterAnimator.SetTrigger("IsLanding");
        }
    }

    private void LateUpdate()
    {
        Jump();
    }
}
