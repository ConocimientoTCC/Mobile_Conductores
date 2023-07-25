using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestsManager : MonoBehaviour
{
    //Puntaje//
    [Header("-- Puntaje --")]
    public Puntaje puntaje;
    //Limpieza//
    [Header("-- Limpieza --")]
    public int stainsCleaned = 0;
    public TMP_Text stainsCleanedText;
    public TMP_Text questText;
    public GameObject[] stainsGO;
    public Toggle toggleLimpieza;
    [Header("-- Kit Carretera --")]
    public GameObject panelKit;
    public GameObject panelKitIntro;
    public GameObject panelKitOutro;
    public TMP_Text questTextKit;
    public Toggle toggleKit;
    [Header("-- Extintor --")]
    public GameObject panelExtintor;
    public GameObject panelExtintorIntro;
    public GameObject panelExtintorOutro;
    public TMP_Text questTextExtintor;
    public Toggle toggleExtintor;
    [Header("-- Botiquín --")]
    public GameObject panelBotiquin;
    public GameObject panelBotiquinIntro;
    public GameObject panelBotiquinOutro;
    public TMP_Text questTextBotiquin;
    public Toggle toggleBotiquin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStains()
    {
        stainsCleaned++;
        stainsCleanedText.SetText(stainsCleaned.ToString());
        if (stainsCleaned >= 3)
        {
            toggleLimpieza.isOn = true;
            questText.fontStyle = FontStyles.Strikethrough;

            puntaje.AumentarPuntaje(5);
        }
    }

    public void CompleteKit()
    {
        if (toggleKit.isOn == false)
        {
            puntaje.AumentarPuntaje(5);
        }
        toggleKit.isOn = true;
        questTextKit.fontStyle = FontStyles.Strikethrough;
        panelKitIntro.SetActive(false);
        panelKitOutro.SetActive(true);
        
    }

    public void CompleteExtintor()
    {
        if (toggleExtintor.isOn == false)
        {
            puntaje.AumentarPuntaje(5);
        }
        toggleExtintor.isOn = true;
        questTextExtintor.fontStyle = FontStyles.Strikethrough;
        panelExtintorIntro.SetActive(false);
        panelExtintorOutro.SetActive(true);

    }

    public void CompleteBotiquin()
    {
        if (toggleBotiquin.isOn == false)
        {
            puntaje.AumentarPuntaje(5);
        }
        toggleBotiquin.isOn = true;
        questTextBotiquin.fontStyle = FontStyles.Strikethrough;
        panelBotiquinIntro.SetActive(false);
        panelBotiquinOutro.SetActive(true);

    }
}
