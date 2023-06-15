using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionPanelScript : MonoBehaviour
{
    public TMP_Text feedbackText;
    public TMP_Text questionText;
    public Button[] answerButtons;

    private EventManagerScript eventManager;

    void Start()
    {
        eventManager = FindObjectOfType<EventManagerScript>();
        UpdateQuestionPanel();
    }

    public void UpdateQuestionPanel()
    {
        Question currentQuestion = eventManager.GetCurrentQuestion();

        questionText.text = currentQuestion.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < currentQuestion.answers.Count)
            {
                answerButtons[i].gameObject.SetActive(true);
                answerButtons[i].GetComponentInChildren<TMP_Text>().text = currentQuestion.answers[i];
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnAnswerButtonClicked(int answerIndex)
    {
        Question currentQuestion = eventManager.GetCurrentQuestion();

        

        if (answerIndex == currentQuestion.correctAnswerIndex)
        {
            feedbackText.text = currentQuestion.feedbackCorrect;
        }
        else
        {
            feedbackText.text = currentQuestion.feedbackWrong;
        }

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(false);
        }

        eventManager.completed = true;
        

        //eventManager.MoveToNextQuestion();
        //UpdateQuestionPanel();
    }

}
