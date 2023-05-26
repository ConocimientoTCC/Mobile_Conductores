using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamion : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del camión
    public GeneradorSeccionesCarretera generadorSeccionesCarretera; // Referencia al script del generador de secciones de la carretera

    private void Update()
    {
        // Mover el camión hacia adelante a una velocidad constante
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);

        // Comprobar si una sección de carretera ha salido de la pantalla
        //if (transform.position.z > generadorSeccionesCarretera.posicionGeneracionX - (generadorSeccionesCarretera.numSeccionesVisibles * generadorSeccionesCarretera.distanciaGeneracion))
        //{
        //    generadorSeccionesCarretera.GenerarSeccionCarretera();
        //    GameObject seccion = generadorSeccionesCarretera.seccionesReciclables.Dequeue();
        //    generadorSeccionesCarretera.SeccionCarreteraFueraDePantalla(seccion);
        //}
    }
}




