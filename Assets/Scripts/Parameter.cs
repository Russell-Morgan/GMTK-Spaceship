using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Parameter : MonoBehaviour
{
    [SerializeField]
    protected float angle;
    public virtual float Angle
    {
        get
        {
            return angle;
        }

        set
        {
            angle = value;
        }
    }

    [SerializeField]
    protected float speed;
    public virtual float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public void RandomizeSpeed()
    {
        Speed = Random.Range(1, 7);
    }
}

