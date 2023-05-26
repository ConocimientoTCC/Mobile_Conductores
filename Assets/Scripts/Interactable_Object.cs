using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Object : MonoBehaviour
{
    public BasicsManager basicsManager;
    private bool isInteractable;
    private bool isTouchingUI = false;

    //int interactiveLayerMask;

    private void Start()
    {

        //
        // Habilitar la interacción táctil en dispositivos móviles
#if UNITY_ANDROID || UNITY_IOS
        isInteractable = true;
#endif

        // Habilitar la interacción con clic en PC
#if UNITY_STANDALONE || UNITY_EDITOR
        isInteractable = true;
#endif
    }

    private void Update()
    {
        // Verificar si se ha tocado el objeto en dispositivos móviles
        if (isInteractable && Input.touchCount > 0 && isTouchingUI != true)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        // Ejecutar la función de interacción
                        PerformInteraction();
                    }
                }
            }
        }

        // Verificar si se hizo clic en el objeto en PC
        if (isInteractable && Input.GetMouseButtonDown(0) && isTouchingUI != true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // Ejecutar la función de interacción
                    PerformInteraction();
                }
            }
        }
    }

    private void PerformInteraction()
    {
        // Aquí puedes agregar la lógica de tu función de interacción
        if(this.gameObject.name == "ManualOperativo")
        {
            basicsManager.OpenManualCanvas();
        }
        else if(this.gameObject.name == "Documentos")
        {

        }
        
    }

    public void OnPointerEnterUI()
    {
        isTouchingUI = true;
    }

    public void OnPointerExitUI()
    {
        isTouchingUI = false;
    }

}

