using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master_Start : MonoBehaviour
{
    public PlayFabManager playfabManager;
    
    [Header("Paneles")]
    public GameObject gameScreen, registerScreen, loginScreen, alertPanel;
    // Start is called before the first frame update
    void Start()
    {
        //if()
        
        gameScreen.SetActive(false);
        loginScreen.SetActive(true);
        registerScreen.SetActive(false);
        //Debug.Log(playfabManager.loggedInPlayfabId);
        //if(playfabManager == null) { playfabManager = FindAnyObjectByType<PlayFabManager>(); }  
        //if(playfabManager.loggedInPlayfabId == null || playfabManager.loggedInPlayfabId == "")
        //{
        //    gameScreen.SetActive(false);
        //    loginScreen.SetActive(true);
        //    registerScreen.SetActive(false);
        //}
        //else
        //{
        //    gameScreen.SetActive(true);
        //    loginScreen.SetActive(false);
        //    registerScreen.SetActive(false);
        //}
    }

    void Update()
    {
        //Debug.Log(playfabManager.loggedInPlayfabId);    
    }

    public void SwitchLoginPanel()
    {
        if (loginScreen.activeInHierarchy == true)
        {
            loginScreen.SetActive(false);
            registerScreen.SetActive(true);
        }
        else
        {
            loginScreen.SetActive(true);
            registerScreen.SetActive(false);
        }
    }

    public void CloseAlertPanel()
    {
        alertPanel.SetActive(false);
        loginScreen.SetActive(false);
        registerScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

}
