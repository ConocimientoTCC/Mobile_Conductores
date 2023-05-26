using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Camera_Mov : MonoBehaviour
{
    public float zoomSpeed = 1f;
    public float maxZoomOut = 5f;
    public float maxZoomIn = 1f;

    private float currentZoom;
    private bool isZoomingOut;

    private void Start()
    {
        currentZoom = Camera.main.fieldOfView;
        isZoomingOut = true;
    }

    private void Update()
    {
        if (isZoomingOut)
        {
            currentZoom -= zoomSpeed * Time.deltaTime;
            if (currentZoom <= maxZoomIn)
                isZoomingOut = false;
        }
        else
        {
            currentZoom += zoomSpeed * Time.deltaTime;
            if (currentZoom >= maxZoomOut)
                isZoomingOut = true;
        }

        Camera.main.fieldOfView = currentZoom;
    }
}
