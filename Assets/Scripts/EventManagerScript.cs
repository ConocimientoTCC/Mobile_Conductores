using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct Question
{
    public string questionText;
    public List<string> answers;
    public string feedbackCorrect;
    public string feedbackWrong;
    public int correctAnswerIndex;
    public bool completed;

}



public class EventManagerScript : MonoBehaviour
{
    private QuestionPanelScript questionPanelScript;
    public GameObject questionPanelGO;
    public List<Question> questions;
    private int currentQuestionIndex = 0;

    public float timeBetweenQuestions = 10f;
    private float elapsedTime = 0f;

    public bool completed = false;

    private void Start()
    {
        questionPanelScript = FindObjectOfType<QuestionPanelScript>();
        questionPanelGO = questionPanelScript.GetComponent<GameObject>();
    }
    private void Update()
    {
        if(completed == true)
        {
            elapsedTime += Time.deltaTime;
        }
        

        if (elapsedTime >= timeBetweenQuestions)
        {
            elapsedTime = 0f;
            MoveToNextQuestion();
        }
    }
    public Question GetCurrentQuestion()
    {
        return questions[currentQuestionIndex];
    }

    public void MoveToNextQuestion()
    {
        
        if(completed == true)
        {

            currentQuestionIndex++;
            if (currentQuestionIndex >= questions.Count)
            {
                currentQuestionIndex = 0; // Regresar al inicio si se ha alcanzado el final de la lista
            
            }
            questionPanelScript.UpdateQuestionPanel();
            completed = false;
        }
    }
}

