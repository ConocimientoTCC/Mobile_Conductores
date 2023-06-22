using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resp_PanelManager : MonoBehaviour
{
    private int currentPanelIndex = 0;
    private GameObject[] panels;

    private void Start()
    {
        // Obtener todos los paneles hijos del objeto PanelManager
        panels = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            panels[i] = transform.GetChild(i).gameObject;
        }

        // Mostrar el primer panel y ocultar los dem�s
        ShowCurrentPanel();
    }

    public void NextPanel()
    {
        // Ocultar el panel actual
        panels[currentPanelIndex].SetActive(false);

        // Incrementar el �ndice del panel actual
        currentPanelIndex++;

        // Verificar si se alcanz� el final de los paneles y volver al principio si es as�
        if (currentPanelIndex >= panels.Length)
        {
            currentPanelIndex = 0;
        }

        // Mostrar el siguiente panel
        ShowCurrentPanel();
    }

    public void PreviousPanel()
    {
        // Ocultar el panel actual
        panels[currentPanelIndex].SetActive(false);

        // Decrementar el �ndice del panel actual
        currentPanelIndex--;

        // Verificar si se alcanz� el inicio de los paneles y volver al final si es as�
        if (currentPanelIndex < 0)
        {
            currentPanelIndex = panels.Length - 1;
        }

        // Mostrar el panel anterior
        ShowCurrentPanel();
    }

    private void ShowCurrentPanel()
    {
        // Mostrar el panel actual
        panels[currentPanelIndex].SetActive(true);
    }

    public void RestorePanelIndex()
    {
        currentPanelIndex = 0;
    }
}

