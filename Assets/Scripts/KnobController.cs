using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobController : MonoBehaviour
{
    public Transform pivot;

    public Animator animator;

    [SerializeField]
    float value;
    public float Value
    {
        get
        {
            return value;
        }

        set
        {
            this.value = value;
            
            if(this.value > 1.0f)
            {
                this.value = 0.0f;
            }

            if (this.value < 0.0f)
            {
                this.value = 1.0f;
            }
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            Value += Time.deltaTime;

            animator.SetFloat("Blend", Value);
        }
    }


}
