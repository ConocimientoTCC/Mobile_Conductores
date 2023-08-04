using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager_Mec : MonoBehaviour
{
    public Question_Mec[] questions; // Lista de preguntas que muestra este panel
    public GameObject resultPanel; // Panel para mostrar la alerta de resultado
    public TMP_Text resultTitle, resultText;
    public GameObject finishButton; // Bot�n para terminar el cuestionario

    private bool isQuizFinished = false; // Bandera para indicar si el cuestionario est� terminado

    public void StartQuiz()
    {
        // Mostrar todas las preguntas en este panel
        foreach (Question_Mec question in questions)
        {
            // Aqu� podr�as acceder a la pregunta, sus respuestas y configurar los botones en el panel
            // Para cada pregunta, tambi�n deber�as asignar un identificador �nico o usar el �ndice dentro del array.
            // Por ejemplo, podr�as usar el �ndice del loop como identificador.
        }
    }

    public void testing(int questionIdentifier)
    {
        //if (!isQuizFinished)
        //{
        //    // Obtener la pregunta actual por su identificador �nico o �ndice en el array de preguntas
        //    Question_Mec currentQuestion = questions[questionIdentifier];

        //    // Verificar si la respuesta es correcta o incorrecta
        //    bool isCorrect = selectedAnswerIndex == currentQuestion.correctAnswerIndex;

        //    // Mostrar la alerta de resultado y manejar la l�gica para mostrar la siguiente pregunta o finalizar el cuestionario
        //    ShowResult(isCorrect);
        //}
    }
    public void SelectAnswerBtn(int questionIdentifier, int selectedAnswerIndex)
    {
        if (!isQuizFinished)
        {
            // Obtener la pregunta actual por su identificador �nico o �ndice en el array de preguntas
            Question_Mec currentQuestion = questions[questionIdentifier];

            // Verificar si la respuesta es correcta o incorrecta
            bool isCorrect = selectedAnswerIndex == currentQuestion.correctAnswerIndex;

            // Mostrar la alerta de resultado y manejar la l�gica para mostrar la siguiente pregunta o finalizar el cuestionario
            //ShowResult(isCorrect);
        }
    }

    private void ShowResult(bool isCorrect)
    {
        // Mostrar la alerta (panel) de resultado correcto o incorrecto
        resultPanel.SetActive(true);
        if(isCorrect == true)
        {
            resultTitle.text = "Perfecto";
        }
        else
        {
            resultTitle.text = "Ups...";
        }
        

        // Aqu� podr�as manejar la l�gica para pasar a la siguiente pregunta o finalizar el cuestionario.
        // Puedes implementar un sistema de navegaci�n entre preguntas dentro del mismo panel.
        // Si es el �ltimo panel, puedes activar el bot�n de "Terminado" en el QuizManager.

        // Ejemplo de c�mo podr�a ser la l�gica para pasar a la siguiente pregunta:
        // Al finalizar el resultado, desactivas la alerta y pasas a la siguiente pregunta en el panel.
        // Si no hay m�s preguntas, activas el bot�n de "Terminado" en el QuizManager.

        // Pasar a la siguiente pregunta despu�s de un breve retraso (2 segundos en este caso)
        Invoke("ShowNextQuestion", 2f);
    }

    private void ShowNextQuestion()
    {
        // Desactivar la alerta de resultado
        resultPanel.SetActive(false);

        // Aqu� podr�as implementar la l�gica para mostrar la siguiente pregunta dentro de este panel.
        // Por ejemplo, puedes desactivar la pregunta actual y activar la siguiente pregunta.

        // Si no hay m�s preguntas, podr�as activar el bot�n de "Terminado" en el QuizManager
        // o pasar al siguiente panel si tienes m�s paneles con preguntas.

        // Ejemplo:
        // Desactivar pregunta actual
        // currentQuestion.SetActive(false);

        // Obtener el �ndice de la siguiente pregunta
        // int nextQuestionIndex = currentQuestionIndex + 1;

        // Si hay m�s preguntas en este panel
        // if (nextQuestionIndex < questions.Length)
        // {
        //     // Activar la siguiente pregunta
        //     questions[nextQuestionIndex].SetActive(true);
        // }
        // else
        // {
        //     // Si no hay m�s preguntas, el cuestionario est� terminado en este panel
        //     // Activa el bot�n de "Terminado" en el QuizManager
        //     isQuizFinished = true;
        //     finishButton.SetActive(true);
        // }
    }
}
