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
    public TMP_Text questTextKit;
    public Toggle toggleKit;
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
        panelKit.SetActive(false);
        
    }
}
