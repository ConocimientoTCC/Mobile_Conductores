using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puntaje : MonoBehaviour
{
    public PlayFabManager playfabManager;
    public int puntajeInicial = 0; // Puntaje inicial
    private int puntajeActual; // Puntaje actual
    private TMP_Text textoPuntaje; // Referencia al componente de texto en la UI

    private void Start()
    {
        playfabManager = FindAnyObjectByType<PlayFabManager>();
        // Obtener la referencia al componente de texto en la UI
        textoPuntaje = GetComponent<TMP_Text>();

        // Establecer el puntaje inicial
        puntajeActual = puntajeInicial;

        // Actualizar la UI con el puntaje inicial
        ActualizarUI();
    }

    public void AumentarPuntaje(int qtty)
    {
        // Incrementar el puntaje en 1
        puntajeActual += qtty;

        // Actualizar la UI con el nuevo puntaje
        ActualizarUI();
        //playfabManager.SendLeaderboard(puntajeActual); //--------- Enviar información a la DB de PlayFab
    }

    private void ActualizarUI()
    {
        // Actualizar el texto en la UI con el puntaje actual
        textoPuntaje.text = puntajeActual.ToString();
    }
}

