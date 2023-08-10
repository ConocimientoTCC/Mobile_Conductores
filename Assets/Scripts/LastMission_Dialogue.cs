using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LastMission_Dialogue : MonoBehaviour
{
    public Transform player;
    public GameObject btnDialogue;
    public GameObject btnContinue;
    public GameObject dialoguePanel;
    public GameObject canvasMobileControls, panelControles_1, panelControles_2;
    public TMP_Text dialogueText;
    public GameObject auraEstadoMec;
    public GameObject colliderEstadoMec;
    public string[] dialogue;
    private int index;

    Coroutine lastRoutine = null;

    public float wordSpeed;
    public bool playerIsClose;
    public float minDist = 4f;

    public AudioSource dialogueSound;

    // Update is called once per frame
    void Update()
    {
        if (dialogueText.text == dialogue[index])
        {
            btnContinue.SetActive(true);
        }

      
    }

    public void OpenDialogue()
    {
        
        canvasMobileControls.SetActive(false);
        dialoguePanel.SetActive(true);
        lastRoutine = StartCoroutine(Typing());
       
    }

    public void CloseDialogue()
    {

        zeroTexto();
        canvasMobileControls.SetActive(true);

    }

    public void zeroTexto()
    {
        
        dialogueText.text = "";
        index = 0;
        StopCoroutine(lastRoutine);
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueSound.Play();
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        btnContinue.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroTexto();
            canvasMobileControls.SetActive(true);
            panelControles_1.SetActive(true);
            panelControles_2.SetActive(true);
            btnDialogue.SetActive(false);
            auraEstadoMec.SetActive(true);
            colliderEstadoMec.SetActive(true);

        }
    }
}

