using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager_Mec : MonoBehaviour
{
    public Question_Mec[] questions; // Lista de preguntas que muestra este panel
    public GameObject resultPanel; // Panel para mostrar la alerta de resultado
    public TMP_Text resultTitle, resultText;
    public GameObject finishButton; // Botón para terminar el cuestionario

    private bool isQuizFinished = false; // Bandera para indicar si el cuestionario está terminado

    public void StartQuiz()
    {
        // Mostrar todas las preguntas en este panel
        foreach (Question_Mec question in questions)
        {
            // Aquí podrías acceder a la pregunta, sus respuestas y configurar los botones en el panel
            // Para cada pregunta, también deberías asignar un identificador único o usar el índice dentro del array.
            // Por ejemplo, podrías usar el índice del loop como identificador.
        }
    }

    public void testing(int questionIdentifier)
    {
        //if (!isQuizFinished)
        //{
        //    // Obtener la pregunta actual por su identificador único o índice en el array de preguntas
        //    Question_Mec currentQuestion = questions[questionIdentifier];

        //    // Verificar si la respuesta es correcta o incorrecta
        //    bool isCorrect = selectedAnswerIndex == currentQuestion.correctAnswerIndex;

        //    // Mostrar la alerta de resultado y manejar la lógica para mostrar la siguiente pregunta o finalizar el cuestionario
        //    ShowResult(isCorrect);
        //}
    }
    public void SelectAnswerBtn(int questionIdentifier, int selectedAnswerIndex)
    {
        if (!isQuizFinished)
        {
            // Obtener la pregunta actual por su identificador único o índice en el array de preguntas
            Question_Mec currentQuestion = questions[questionIdentifier];

            // Verificar si la respuesta es correcta o incorrecta
            bool isCorrect = selectedAnswerIndex == currentQuestion.correctAnswerIndex;

            // Mostrar la alerta de resultado y manejar la lógica para mostrar la siguiente pregunta o finalizar el cuestionario
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
        

        // Aquí podrías manejar la lógica para pasar a la siguiente pregunta o finalizar el cuestionario.
        // Puedes implementar un sistema de navegación entre preguntas dentro del mismo panel.
        // Si es el último panel, puedes activar el botón de "Terminado" en el QuizManager.

        // Ejemplo de cómo podría ser la lógica para pasar a la siguiente pregunta:
        // Al finalizar el resultado, desactivas la alerta y pasas a la siguiente pregunta en el panel.
        // Si no hay más preguntas, activas el botón de "Terminado" en el QuizManager.

        // Pasar a la siguiente pregunta después de un breve retraso (2 segundos en este caso)
        Invoke("ShowNextQuestion", 2f);
    }

    private void ShowNextQuestion()
    {
        // Desactivar la alerta de resultado
        resultPanel.SetActive(false);

        // Aquí podrías implementar la lógica para mostrar la siguiente pregunta dentro de este panel.
        // Por ejemplo, puedes desactivar la pregunta actual y activar la siguiente pregunta.

        // Si no hay más preguntas, podrías activar el botón de "Terminado" en el QuizManager
        // o pasar al siguiente panel si tienes más paneles con preguntas.

        // Ejemplo:
        // Desactivar pregunta actual
        // currentQuestion.SetActive(false);

        // Obtener el índice de la siguiente pregunta
        // int nextQuestionIndex = currentQuestionIndex + 1;

        // Si hay más preguntas en este panel
        // if (nextQuestionIndex < questions.Length)
        // {
        //     // Activar la siguiente pregunta
        //     questions[nextQuestionIndex].SetActive(true);
        // }
        // else
        // {
        //     // Si no hay más preguntas, el cuestionario está terminado en este panel
        //     // Activa el botón de "Terminado" en el QuizManager
        //     isQuizFinished = true;
        //     finishButton.SetActive(true);
        // }
    }
}
