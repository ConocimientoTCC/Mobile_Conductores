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
    public GameObject panelIntroKit;
    public GameObject panelOutroKit;

    public GameObject canvasExtintor;
    public GameObject panelIntroExtintor; 
    public GameObject panelOutroExtintor;

    public GameObject canvasBotiquin;
    public GameObject panelIntroBotiquin;
    public GameObject panelOutroBotiquin;

    public GameObject canvasMecanico;
    public GameObject panelIntroMecanico;
    public GameObject panelOutroMecanico;

    public GameObject PanelPause;

    public Animator questsBtnAnim;
    

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
        questsBtnAnim.SetBool("PlayAnim", true);
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
        panelIntroKit.SetActive(true);
        panelOutroKit.SetActive(false);
    }

    public void OpenExtintorCanvas()
    {
        canvasExtintor.SetActive(true);
        panelIntroExtintor.SetActive(true);
        panelOutroExtintor.SetActive(false);
    }

    public void OpenBotiquinCanvas()
    {
        canvasBotiquin.SetActive(true);
        panelIntroBotiquin.SetActive(true);
        panelOutroBotiquin.SetActive(false);
    }

    public void OpenMecanicoCanvas()
    {
        canvasMecanico.SetActive(true);
        panelIntroMecanico.SetActive(true);
        panelOutroMecanico.SetActive(false);
    }

    public void CloseKitCanvas()
    {
        canvasKit.SetActive(false);
    }

    public void CloseExtintorCanvas()
    {
        canvasExtintor.SetActive(false);
    }

    public void CloseBotiquinCanvas()
    {
        canvasBotiquin.SetActive(false);
    }

    public void CloseMecanicoCanvas()
    {
        canvasMecanico.SetActive(false);
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

    public void CancelAnim()
    {
        if (questsBtnAnim.GetBool("PlayAnim") == true)
        {
            questsBtnAnim.SetBool("PlayAnim", false);
        }
    }
}
