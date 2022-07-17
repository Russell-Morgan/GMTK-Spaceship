using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public static float VolumeAmount = 1f;
   // private AudioSource[] hinge;

    // Start is called before the first frame update
    void Start()
    {
       
        AudioListener.volume = VolumeAmount;

    }

    public void UpdateVolume( float NewAmmount)
    {
       VolumeAmount = NewAmmount;
       AudioListener.volume = VolumeAmount;
    }

    // Update is called once per frame

}
