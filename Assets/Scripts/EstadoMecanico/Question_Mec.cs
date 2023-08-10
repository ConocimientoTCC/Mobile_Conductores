using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Question_Mec : MonoBehaviour
{
    // public string[] answers; // Arreglo de respuestas (2 respuestas en este caso)
    
    public int correctAnswerIndex; // Índice de la respuesta correcta
    public AlertManager alertManager;
    public QuestsManager questsManager;
    public Button otherButton;

    private void Start()
    {
        if (alertManager == null)
        {
            alertManager = GameObject.Find("AlertManager").GetComponent<AlertManager>();
        }
        if (questsManager == null)
        {
            questsManager = GameObject.Find("QuestsManager").GetComponent<QuestsManager>();
        }
    }
    public void SelectedAnswer(int answerIndex)
    {
        if (answerIndex == correctAnswerIndex)
        {
            Debug.Log("Correcto");
            this.gameObject.GetComponent<Button>().interactable = false;
            otherButton.interactable = false;
            alertManager.CorrectAlert();
            questsManager.UpdateQuestions();
        }
        else
        {
            Debug.Log("Incorrecto");
            questsManager.puntaje.RestarPuntaje(2);
            alertManager.WrongAlert();
        }
    }
}



