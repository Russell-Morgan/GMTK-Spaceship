using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriggerEffects : MonoBehaviour
{
    public int Effect = 1;
    public MenuManager ManagerOfMenus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        //  Specifies that the item entered is the ship and not just any object
        if (col.GetComponent<ShipController>())
        { 
        switch (Effect)
        {
            case 1:
                // Win condition
                ManagerOfMenus.WinLevel();

                break;

            case 2:
                // Lose Condition
                ManagerOfMenus.LostLevel();

                break;

            default:

                break;
        }
      }
    }

   }
