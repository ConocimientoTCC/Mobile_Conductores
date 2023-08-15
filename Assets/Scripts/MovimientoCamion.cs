using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamion : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del cami�n
    public GeneradorSeccionesCarretera generadorSeccionesCarretera; // Referencia al script del generador de secciones de la carretera

    private void Update()
    {
        // Mover el cami�n hacia adelante a una velocidad constante
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);

#if UNITY_EDITOR
        // Verifica si est�s en el editor de Unity (usando el mouse)
        if (Input.GetMouseButton(0)) // 0 representa el bot�n izquierdo del mouse
        {
            HandleInput();
        }
#else
        // Verifica si est�s en un dispositivo m�vil (usando entrada t�ctil)
        if (Input.touchCount > 0)
        {
            HandleInput();
        }
#endif
    }

    void HandleInput()
    {
        float screenHalf = Screen.width / 2f;
        int direction = 0;

#if UNITY_EDITOR
        // Maneja la entrada del mouse en el editor
        if (Input.mousePosition.x < screenHalf)
        {
            //MoveTruck(-1); // Mover hacia la izquierda
            direction = 1;
        }
        else
        {
            //MoveTruck(1); // Mover hacia la derecha
            direction = -1;
        }
#else
        // Maneja la entrada t�ctil en un dispositivo m�vil
        Touch touch = Input.GetTouch(0);
        if (touch.position.x < screenHalf)
        {
            MoveTruck(1); // Mover hacia la izquierda
        }
        else
        {
            MoveTruck(-1); // Mover hacia la derecha
        }
#endif
        MoveTruck(direction);
    }

    void MoveTruck(int direction)
    {
        // Mueve el cami�n en la direcci�n especificada
        if(transform.position.x <= 3.0 && transform.position.x >= -2.4)
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, direction * velocidad * Time.deltaTime);
            transform.Translate(movement);
        }
        else if(transform.position.x > 3.0)
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, 0.4f);
            transform.Translate(movement);
        }
        else if(transform.position.x < -2.4)
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, -0.4f);
            transform.Translate(movement);
        }

        
    }

}
// Comprobar si una secci�n de carretera ha salido de la pantalla
//if (transform.position.z > generadorSeccionesCarretera.posicionGeneracionX - (generadorSeccionesCarretera.numSeccionesVisibles * generadorSeccionesCarretera.distanciaGeneracion))
//{
//    generadorSeccionesCarretera.GenerarSeccionCarretera();
//    GameObject seccion = generadorSeccionesCarretera.seccionesReciclables.Dequeue();
//    generadorSeccionesCarretera.SeccionCarreteraFueraDePantalla(seccion);
//}



