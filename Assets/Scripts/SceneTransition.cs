using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator Overlay;
    public string GameScene1;
   // private string GameScene2 = "Menu";
    public void Scene1()
    {
        StartCoroutine(WaitTheFadeOut(GameScene1));
       // SceneManager.LoadScene(GameScene1);
    }
    public void ResetScene()
    {
        string temp = SceneManager.GetActiveScene().name;

        StartCoroutine(WaitTheFadeOut(temp));
    }
    public void ChangeScene( string SceneName)
    {
        StartCoroutine(WaitTheFadeOut(SceneName));
    }


    IEnumerator WaitTheFadeOut(string SceneName)
    {
        //Print the time of when the function is first called.
        //   Debug.Log("Started Coroutine at timestamp : " + Time.time);

        if (Overlay != null)
        Overlay.GetComponent<Animator>().SetBool("FadeOut", true);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(1);

        Time.timeScale = 1;
         SceneManager.LoadScene(SceneName);

        //After we have waited 5 seconds print the time again.
        //  Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
