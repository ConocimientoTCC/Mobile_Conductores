using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BasicsManager : MonoBehaviour
{
    public GameObject panelToKeepActive;
    public GameObject PanelManager;
    public GameObject canvasManual;
    public GameObject canvasMobileControls;

    public void ChangeScene(int number)
    {
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

    public void OpenManualCanvas()
    {
        canvasMobileControls.SetActive(false);
        canvasManual.SetActive(true);
        panelToKeepActive.SetActive(true);
    }

    public void ExitApp()
    {
        Application.Quit();

    }
}
