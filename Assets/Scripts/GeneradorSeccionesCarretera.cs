using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorSeccionesCarretera : MonoBehaviour
{
    public GameObject seccionCarreteraPrefab; // Prefab de la sección de la carretera
    public Transform camion; // Transform del camión
    public float distanciaGeneracion = 100f; // Distancia entre cada sección generada
    public int numSeccionesVisibles = 5; // Número de secciones visibles en pantalla
    public float tiempoDestruccion = 5f; // Tiempo de destrucción de la sección de carretera

    private Queue<GameObject> seccionesReciclables = new Queue<GameObject>(); // Cola de secciones de la carretera reciclables
    private float posicionGeneracionZ = 0f; // Posición Z para generar la siguiente sección de la carretera
    private List<GameObject> seccionesGeneradas = new List<GameObject>(); // Lista de secciones de carretera generadas

    private void Start()
    {
        GenerarSeccionesIniciales();
    }

    private void GenerarSeccionesIniciales()
    {
        for (int i = 0; i < numSeccionesVisibles; i++)
        {
            GenerarSeccionCarretera();
        }
    }

    private void GenerarSeccionCarretera()
    {
        GameObject seccion;

        if (seccionesReciclables.Count > 0)
        {
            seccion = seccionesReciclables.Dequeue();
            seccion.SetActive(true);
        }
        else
        {
            seccion = Instantiate(seccionCarreteraPrefab, transform);
        }

        seccion.transform.position = new Vector3(0f, 0f, posicionGeneracionZ);
        posicionGeneracionZ += distanciaGeneracion;

        seccionesGeneradas.Add(seccion);

        if (seccionesGeneradas.Count > numSeccionesVisibles)
        {
            StartCoroutine(DestruirPrimeraSeccion());
        }
    }

    private IEnumerator DestruirPrimeraSeccion()
    {
        yield return new WaitForSeconds(tiempoDestruccion);

        GameObject primeraSeccion = seccionesGeneradas[0];
        seccionesGeneradas.RemoveAt(0);
        ReciclarSeccionCarretera(primeraSeccion);
    }

    private void ReciclarSeccionCarretera(GameObject seccion)
    {
        seccion.SetActive(false);
        seccionesReciclables.Enqueue(seccion);
    }

    private void Update()
    {
        if (camion.position.z > posicionGeneracionZ - (numSeccionesVisibles * distanciaGeneracion))
        {
            GenerarSeccionCarretera();
        }
    }
}
