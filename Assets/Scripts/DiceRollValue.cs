using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiceRollValue : MonoBehaviour
{
    bool held = false;

    public TextMeshProUGUI text;

    Vector3 originalPosition;

    private void Start()
    {
        originalPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    public void MouseDown()
    {
        if (!TurnSystem.instance.TurnActive)
        {
            return;
        }
        held = true;
    }

    public void MouseUp()
    {
        if (!TurnSystem.instance.TurnActive)
        {
            return;
        }
        var images = RaycastMouse();

        if(held)
        {
            for(int i = 0; i < images.Count; i++)
            {
                if(images[i].gameObject == gameObject)
                {
                    continue;
                }

                var drag = images[i].gameObject.GetComponent<DiceRollValue>();
                if (drag)
                {
                    var oldText = drag.text.text;
                    drag.text.text = text.text;
                    text.text = oldText;

                    break;
                }
            }

            GetComponent<RectTransform>().anchoredPosition = originalPosition;
        }
        held = false;
    }

    private void Update()
    {
        if(!TurnSystem.instance.TurnActive)
        {
            return;
        }

        if(held)
        {
            transform.position = Input.mousePosition;
        }
    }

    public List<RaycastResult> RaycastMouse()
    {

        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            pointerId = -1,
        };

        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);


        return results;
    }
}
