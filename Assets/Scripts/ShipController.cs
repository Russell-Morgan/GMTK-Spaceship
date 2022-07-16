using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float baseSpeed = 15.0f;
    public float turnSpeed = 15.0f;

    [HideInInspector]
    public Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        Movement();

        Turning();

    }

    private void Movement()
    {
        //Forwards
        if (Input.GetKey(KeyCode.Z))
        {
            rigidBody.AddForce(transform.up * baseSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }

        //Backwards
        if (Input.GetKey(KeyCode.X))
        {
            rigidBody.AddForce(-transform.up * baseSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    private void Turning()
    {
        //Turning
        var turnDirection = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1.0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1.0f;
        }
        rigidBody.AddTorque(turnDirection * turnSpeed);
    }
}
