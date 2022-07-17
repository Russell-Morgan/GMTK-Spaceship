using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class TimerManager : MonoBehaviour
{

    float LevelTimeSeconds = 0;
    float LevelTimeMinites = 0;
    public TextMeshProUGUI TimerDisplay;
    public bool Counting = true;
    //public ShipController ship;

    // Start is called before the first frame update
    void Start()
    {
      //  ship = FindObjectOfType<ShipController>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Counting)
        {
            LevelTimeSeconds += Time.deltaTime;
            DisplayTime(LevelTimeSeconds);
        }
    }

    public void SetCounting( bool Set)
    {
        Counting = Set;
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float  milliseconds = (int)(Time.timeSinceLevelLoad * 100f) % 100;
        TimerDisplay.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
