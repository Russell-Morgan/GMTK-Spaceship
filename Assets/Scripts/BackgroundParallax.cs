using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    private float length;
    private Vector3 startpos;
    public new GameObject camera;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float distanceX = (camera.transform.position.x * parallaxEffect);
        float distanceY = (camera.transform.position.y * parallaxEffect);

        transform.position = new Vector3(startpos.x + distanceX, startpos.y + distanceY, transform.position.z);

        float offsetX = (camera.transform.position.x * (1 - parallaxEffect));
        float offsetY = (camera.transform.position.y * (1 - parallaxEffect));

        if (offsetX > startpos.x + length) startpos.x += length;
        else if (offsetX < startpos.x - length) startpos.x -= length;

        if (offsetY > startpos.y + length) startpos.y += length;
        else if (offsetY < startpos.y - length) startpos.y -= length;
    }
}
