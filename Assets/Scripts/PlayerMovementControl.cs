using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



public class PlayerMovementControl : MonoBehaviour {

    [Header("General")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpSpeed = 400f;

    [Header("Reference")]
    [SerializeField] Rigidbody2D rb;

    [Header("No touch")]
    public float xThrow;
    public float xOffset;

    enum State {Jumping , Walking};
    State playerState = State.Jumping;


    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        print(xOffset);
        MovementControl();

    }


    
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag) {

        case "Ground":
            playerState = State.Walking;
            break;

        default:
            break;

        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {

            case "Ground":
                playerState = State.Walking;
                break;

            default:
                break;

        }
    }

    private void MovementControl()
    {
        //Gets the offset
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        xOffset = moveSpeed * xThrow * Time.deltaTime;
        float xRaw = transform.position.x + xOffset;


        //Applies the offset
        transform.position = new Vector3(xRaw, transform.position.y, transform.position.z);

        //Allows the character to jump.
        if (CrossPlatformInputManager.GetButtonDown("Jump") && playerState != State.Jumping)
        {
            rb.AddRelativeForce(transform.up * jumpSpeed);
            playerState = State.Jumping;
        }
    }
}
