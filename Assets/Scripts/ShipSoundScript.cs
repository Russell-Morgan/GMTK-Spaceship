using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSoundScript : MonoBehaviour
{

    public AudioSource source;

    public AudioClip[] clips;

    public float minPitch = 0.5f;
    public float maxPitch = 2.0f;

    public float maxCrashVelocity = 8.0f;
    public float minVelocityForCrash = 1.0f;

    public float lastPlayed;
    public float delayTimer;

    public Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        DebugPlus.LogOnScreen(rb.velocity.magnitude.ToString());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var mag = collision.relativeVelocity.magnitude;
        if(mag < minVelocityForCrash)
        {
            return;
        }
        if(Time.time - lastPlayed < delayTimer)
        {
            return;
        }

        var clip = clips[UnityEngine.Random.Range(0, clips.Length)];

        source.clip = clip;

        var factor = Mathf.Lerp(minPitch, maxPitch, 1-(mag/maxCrashVelocity));

        DebugPlus.LogOnScreen((mag / maxCrashVelocity).ToString()).duration = 2.0f;


        lastPlayed = Time.time;

        source.pitch = factor;
        source.PlayOneShot(source.clip);

    }

}
