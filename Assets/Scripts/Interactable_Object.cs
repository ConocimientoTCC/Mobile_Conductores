using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Interactable_Object : MonoBehaviour
{
    public NPC_Dialogue npcDialogue;
    public BasicsManager basicsManager;
    private bool isInteractable;
    private bool isTouchingUI = false;
    public GameObject imageTouchManual;
    public GameObject imageTouchCarpeta;

    public Transform defaultTarget;
    public Transform target;
    public float minDist = 6f;

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
            UnityEngine.Touch touch = Input.GetTouch(0);
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
            //print("hello1");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    //print("hello2");
                    // Ejecutar la función de interacción
                    PerformInteraction();
                }
            }
        }

        if (this.gameObject.name != "Bobby" && this.gameObject.name != "document_holder")
        {

            float distance = Vector3.Distance(target.position, imageTouchManual.transform.position);
            if (target != null)
            {
                if (distance < minDist)
                {
                    imageTouchManual.transform.LookAt(target);
                    imageTouchManual.SetActive(true);

                    imageTouchCarpeta.transform.LookAt(target);
                    imageTouchCarpeta.SetActive(true);

                    

                    }
                else
                {
                    imageTouchManual.transform.LookAt(defaultTarget);
                    imageTouchManual.SetActive(false);
                    imageTouchCarpeta.transform.LookAt(defaultTarget);
                    imageTouchCarpeta.SetActive(false);
                    

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
        else if(this.gameObject.name == "document_holder")
        {
            basicsManager.OpenDocumentsCanvas();
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

