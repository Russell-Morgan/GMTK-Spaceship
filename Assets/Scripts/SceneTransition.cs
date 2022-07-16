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
    private string GameScene2 = "Menu";
    public void Scene1()
    {
        StartCoroutine(WaitTheFadeOut(GameScene1));
       // SceneManager.LoadScene(GameScene1);
    }
    public void Scene2()
    {
        StartCoroutine(WaitTheFadeOut(GameScene2));
        //SceneManager.LoadScene(GameScene2);
    }
    public void ChangeScene( string SceneName)
    {
        StartCoroutine(WaitTheFadeOut(SceneName));
    }


    IEnumerator WaitTheFadeOut(string SceneName)
    {
        //Print the time of when the function is first called.
        //   Debug.Log("Started Coroutine at timestamp : " + Time.time);

        Overlay.GetComponent<Animator>().SetBool("FadeOut", true);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

         SceneManager.LoadScene(SceneName);

        //After we have waited 5 seconds print the time again.
        //  Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
