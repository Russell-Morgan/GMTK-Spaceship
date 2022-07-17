using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float baseSpeed = 15.0f;
    public float turnSpeed = 15.0f;

    [HideInInspector]
    public Rigidbody2D rigidBody;
    public Animator animator;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

}
