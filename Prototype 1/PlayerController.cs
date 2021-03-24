using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI speedometerText;

    [SerializeField] float rpm;
    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] float horsePower = 20.0f;  
    [SerializeField] float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);

        //Moves the car forward based on the vertical input
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //Rotates the car based on horizontal input
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);

        speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f); // For kph, change 2.237 to 3.6
        speedometerText.SetText("Speed: " + speed + "mph");

        rpm = Mathf.Round(speed % 30) * 40;
        rpmText.SetText("RPM:  " + rpm);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
