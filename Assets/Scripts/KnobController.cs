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

            animator.SetFloat("Blend", this.value);

        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            Value += Time.deltaTime;
        }
    }


    Vector3 mouseDelta = Vector3.zero;
    public void Drag()
    {
        var knobPos = GetComponent<RectTransform>().position;
        var pos = Input.mousePosition - knobPos;

        var angle = Vector3.Angle(Vector2.up, pos);        
        if(Input.mousePosition.x > knobPos.x)
        {
            angle = (180.0f - angle) + 180.0f;
        }

        Value = angle/360.0f;
        
        //mouseDelta = Input.mousePosition;
    }

}
