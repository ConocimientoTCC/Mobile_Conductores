using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BasicsManager : MonoBehaviour
{
    public GameObject panelToKeepActive;
    public GameObject PanelManager;
    public GameObject canvasManual;
    public GameObject canvasDocuments;
    public GameObject canvasMobileControls;
    public GameObject canvasKit;

    public GameObject PanelPause;

    public void ChangeScene(int number)
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(number);
    }

    public void SwitchClosePanel(GameObject panel)
    {
        if(panel.activeInHierarchy == true)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }

    public void CloseManualCanvas()
    {

        foreach (Transform child in PanelManager.transform)
        {
            if (child.gameObject != panelToKeepActive)
            {
                child.gameObject.SetActive(false);
            }
        }
        
        canvasManual.SetActive(false);
        canvasMobileControls.SetActive(true);
    }

    public void CloseDocumentsCanvas(GameObject panel)
    {
        panel.SetActive(false);
        canvasDocuments.SetActive(false);
        canvasMobileControls.SetActive(true);
    }

    public void OpenManualCanvas()
    {
        canvasMobileControls.SetActive(false);
        canvasManual.SetActive(true);
        panelToKeepActive.SetActive(true);
    }

    public void OpenDocumentsCanvas()
    {
        canvasMobileControls.SetActive(false);
        canvasDocuments.SetActive(true);
    }

    public void OpenKitCanvas()
    {
        canvasKit.SetActive(true);
    }

    public void ExitApp()
    {
        Application.Quit();

    }

    public void SwitchPauseGame()
    {
        if(Time.timeScale == 0)
        {
            PanelPause.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            PanelPause.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
}
