using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustAnimator : MonoBehaviour
{
    public ShipController ship;
    public Animator animator;
    void Update()
    {
        animator.SetFloat("Speed", ship.rigidBody.velocity.magnitude);
    }
}
