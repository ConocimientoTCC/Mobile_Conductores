using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestsManager : MonoBehaviour
{
    //public BasicsManager basicsManager;
    //Puntaje//
    public GameObject panelControles_1, panelControles_2;
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
    public GameObject panelBGEstadoMec;
    public TMP_Text questTextEstadoMec;
    public Toggle toggleEstadoMec;
    public bool showBtn = true;
    [Header("-- BADGES --")]
    public GameObject canvasBadges;
    public AudioSource soundBadges;
    // Start is called before the first frame update
    void Start()
    {
        panelBGEstadoMec.SetActive(false);
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
            panelControles_1.SetActive(false);
            panelControles_2.SetActive(false);
            lastMissionDialogueBtn.SetActive(true);
            lastMissionDialogueBtn.GetComponent<Animator>().SetBool("PlayAnim", true);
            panelBGEstadoMec.SetActive(true);
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
            puntaje.AumentarPuntaje(100);
            scoreSound.PlayDelayed(1.5f);
            puntaje.playfabManager.SavePlayerData(puntaje.puntajeActual.ToString());
        }
        toggleEstadoMec.isOn = true;
        questTextEstadoMec.fontStyle = FontStyles.Strikethrough;
        panelEstadoMecIntro.SetActive(false);
        lastPanelMec.SetActive(false);
        panelEstadoMecOutro.SetActive(true);
        numberQuests.text = 0.ToString();

    }

    public void GiveBadge()
    {
        canvasBadges.SetActive(true);
        soundBadges.Play();
    }

    public void OpenBadgeCanvas()
    {
        Invoke("GiveBadge", 2f);
    }

    public void UpdateQuestions()
    {
        questionsAnswered++;
    }

}
