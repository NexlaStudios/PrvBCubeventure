using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraMovement : MonoBehaviour {

    [Header("General")]
    [SerializeField] float cameraMovingPlayerOffset;
    [SerializeField] float cameraClampL = 10.13f;
    [SerializeField] float cameraClampR = 100f;

    [Header("References")]
    [SerializeField] GameObject player;

    private PlayerMovementControl pmc;
    private float xPlayerOffset;

    float xCamera;
    float xCameraThrow;


    void Start()
    {
        pmc = player.GetComponent<PlayerMovementControl>(); /* Sets pmc(which is of type of script) 
        to the PlayerMovementControl (which is a script on "player") */
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        xPlayerOffset = pmc.xOffset; //Gets the public variable xOffset from PlayerMovementControl

        //Gets appropriate throw.
        GetCameraThrow();

        //Calculates the offset
        float xCameraOffset = cameraMovingPlayerOffset * xCameraThrow * 0.02f;

        CameraPositionCalculation(xCameraOffset);

    }



    private void GetCameraThrow() //Gets the public variable xOffset from PlayerMovementControl
    {

        print(CrossPlatformInputManager.GetAxis("Horizontal"));

        if (transform.position.x == cameraClampL || transform.position.x == cameraClampR)
        {
            xCameraThrow = 0f;
        } else
        {
            xCameraThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        }
    }



    private void CameraPositionCalculation(float xCameraOffset)
    {
        if (xPlayerOffset <= Mathf.Epsilon && xPlayerOffset >= -Mathf.Epsilon) //If the player is not moving.
        {
            MoveToPlayer();

        }
        else if (xPlayerOffset > Mathf.Epsilon) //Checks if the player is moving to the right.
        {

            if (transform.position.x == cameraClampL)
            {
                MoveToPlayer();
            }
            else
            {
                xCamera = Mathf.Clamp(player.transform.position.x, cameraClampL, cameraClampR) - xCameraOffset;
                transform.position = new Vector3(xCamera, 0, -10);
            }

        }
        else if (xPlayerOffset < -Mathf.Epsilon) //Checks if the player is moving left.
        {

            if (transform.position.x == cameraClampR)
            {
                MoveToPlayer();
            }
            else
            {
                xCamera = Mathf.Clamp(player.transform.position.x, cameraClampL, cameraClampR) + xCameraOffset;
                transform.position = new Vector3(xCamera, 0, -10);
            }

        }
    }



    private void MoveToPlayer()
    {
        xCamera = Mathf.Clamp(player.transform.position.x, cameraClampL, cameraClampR);
        transform.position = new Vector3(xCamera, 0, -10);
    }



}
