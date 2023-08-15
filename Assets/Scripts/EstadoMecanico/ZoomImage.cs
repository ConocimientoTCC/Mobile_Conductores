using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomImage : MonoBehaviour
{
    public GameObject panelZoom;
    public Image imageNormal;
    public Image imageZoom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Zoom()
    {
        panelZoom.SetActive(true);
        imageZoom.sprite = imageNormal.sprite;
    }
}
