using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private float PauseValue = 1;
    public GameObject WinMenu;
    public GameObject LoseMenu;

    public static float VolumeValue;


    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        // gets the value of time previous, if time was paused before
         PauseValue = Time.timeScale;

        Time.timeScale = 0;

    }

    public void UnpauseGame()
    {
        //returns time value to whatever it was
        Time.timeScale = PauseValue;
    }

    public void ResumeTime()
    {
        // forces time to resume
        Time.timeScale = 1;
    }

    public void WinLevel()
    {
        PauseGame();
        WinMenu.SetActive(true);
    }

    public void LostLevel()
    {
        PauseGame();
        LoseMenu.SetActive(true);
    }

}
