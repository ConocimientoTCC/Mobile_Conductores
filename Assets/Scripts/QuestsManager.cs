using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestsManager : MonoBehaviour
{
    //public BasicsManager basicsManager;
    //Puntaje//
    public LastMission_Dialogue lastMissionDialogue;
    public GameObject lastMissionDialogueBtn;
    public AudioSource achievementSound;
    public AudioSource scoreSound;

    public int subtractQuests = 4;
    public TMP_Text numberQuests;
    public Toggle[] togglesQuests;
    [Header("-- Puntaje --")]
    public Puntaje puntaje;
    //Limpieza//
    [Header("-- Limpieza --")]
    public int stainsCleaned = 0;
    public TMP_Text stainsCleanedText;
    public TMP_Text questText;
    public GameObject[] stainsGO;
    public Toggle toggleLimpieza;
    public AudioSource cleanSound;
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
    [Header("-- Estado Mecánico --")]
    public int questionsAnswered;
    public Button ButtonTerminado;
    public GameObject panelEstadoMec;
    public GameObject panelEstadoMecIntro;
    public GameObject panelEstadoMecOutro;
    public GameObject lastPanelMec;
    public TMP_Text questTextEstadoMec;
    public Toggle toggleEstadoMec;
    public bool showBtn = true;
    // Start is called before the first frame update
    void Start()
    {
        questTextEstadoMec.gameObject.SetActive(false);
        toggleEstadoMec.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        //subtractQuests = int.Parse(numberQuests.text);
        if(toggleLimpieza.isOn == true && toggleKit.isOn == true && toggleExtintor.isOn == true && toggleBotiquin.isOn == true && showBtn == true)
        {
            print("puutamadre");
            showBtn = false;
            lastMissionDialogueBtn.SetActive(true);
            questTextEstadoMec.gameObject.SetActive(true);
            toggleEstadoMec.gameObject.SetActive(true);
            numberQuests.text = 1.ToString();
        }

        if(questionsAnswered == 14)
        {
            ButtonTerminado.interactable = true;
        }

        
    }

    public void UpdateQuests()
    {
        subtractQuests = 4;
        for (int i = 0; i < togglesQuests.Length; i++)
        {
            if (togglesQuests[i].isOn)
            {
                subtractQuests -= 1;
                print(subtractQuests.ToString());
                numberQuests.text = subtractQuests.ToString();
                
            }
            
        }
    }

    public void UpdateStains()
    {
        stainsCleaned++;
        stainsCleanedText.SetText(stainsCleaned.ToString());
        cleanSound.Play();
        if (stainsCleaned >= 3)
        {
            toggleLimpieza.isOn = true;
            questText.fontStyle = FontStyles.Strikethrough;

            achievementSound.Play();
            puntaje.AumentarPuntaje(5);
            scoreSound.PlayDelayed(1.5f);
            UpdateQuests();
        }
    }

    public void CompleteKit()
    {
        if (toggleKit.isOn == false)
        {
            achievementSound.Play();
            puntaje.AumentarPuntaje(5);
            scoreSound.PlayDelayed(1.5f);
            
        }
        toggleKit.isOn = true;
        questTextKit.fontStyle = FontStyles.Strikethrough;
        panelKitIntro.SetActive(false);
        panelKitOutro.SetActive(true);
        UpdateQuests();

    }

    public void CompleteExtintor()
    {
        if (toggleExtintor.isOn == false)
        {
            achievementSound.Play();
            puntaje.AumentarPuntaje(5);
            scoreSound.PlayDelayed(1.5f);
            
        }
        toggleExtintor.isOn = true;
        questTextExtintor.fontStyle = FontStyles.Strikethrough;
        panelExtintorIntro.SetActive(false);
        panelExtintorOutro.SetActive(true);
        UpdateQuests();

    }

    public void CompleteBotiquin()
    {
        if (toggleBotiquin.isOn == false)
        {
            achievementSound.Play();
            puntaje.AumentarPuntaje(5);
            scoreSound.PlayDelayed(1.5f);
            
        }
        toggleBotiquin.isOn = true;
        questTextBotiquin.fontStyle = FontStyles.Strikethrough;
        panelBotiquinIntro.SetActive(false);
        panelBotiquinOutro.SetActive(true);
        UpdateQuests();

    }

    public void CompleteEstadoMecanico()
    {
        if (toggleEstadoMec.isOn == false)
        {
            achievementSound.Play();
            puntaje.AumentarPuntaje(10);
            scoreSound.PlayDelayed(1.5f);
            
        }
        toggleEstadoMec.isOn = true;
        questTextEstadoMec.fontStyle = FontStyles.Strikethrough;
        panelEstadoMecIntro.SetActive(false);
        lastPanelMec.SetActive(false);
        panelEstadoMecOutro.SetActive(true);
        numberQuests.text = 0.ToString();

    }

    public void UpdateQuestions()
    {
        questionsAnswered++;
    }

}
