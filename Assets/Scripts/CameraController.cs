using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public float minZoom = 2.5f;
    public float maxZoom = 40.0f;

    public CinemachineVirtualCamera cam;

    public float cameraLerpSpeed = 1.0f;
    public float scrollWheelMult = 1.0f;
    public float currentZoom = 10.0f;
    public float targetZoom = 10.0f;

    private void Start()
    {
        cam.Follow = GameObject.FindObjectOfType<ShipController>().gameObject.transform;
    }

    void Update()
    {

        targetZoom += -Input.mouseScrollDelta.y * scrollWheelMult;

        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);

        var lensSize = cam.m_Lens.OrthographicSize;

        cam.m_Lens.OrthographicSize = Mathf.Lerp(lensSize, targetZoom, Time.deltaTime * cameraLerpSpeed);
    }
}
