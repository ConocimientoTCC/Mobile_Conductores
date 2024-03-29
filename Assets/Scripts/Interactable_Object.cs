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
    public GameObject imageTouchKit;
    public GameObject imageTouchExtintor;
    public GameObject imageTouchBotiquin;

    public Transform defaultTarget;
    public Transform target;
    public float minDist = 6f;

    public SoundManagerPreop soundManagerPreop;

    //int interactiveLayerMask;

    private void Start()
    {
        if (soundManagerPreop == null)
        {
            soundManagerPreop = GameObject.Find("SoundManager_Preop").GetComponent<SoundManagerPreop>();
        }

        //
        // Habilitar la interacci�n t�ctil en dispositivos m�viles
#if UNITY_ANDROID || UNITY_IOS
        isInteractable = true;
#endif

        // Habilitar la interacci�n con clic en PC
#if UNITY_STANDALONE || UNITY_EDITOR
        isInteractable = true;
#endif
    }

    private void Update()
    {
        //print("touchingui="+isTouchingUI);
        // Verificar si se ha tocado el objeto en dispositivos m�viles
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
                        // Ejecutar la funci�n de interacci�n
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
                    // Ejecutar la funci�n de interacci�n
                    if(this.gameObject.name != "Bobby")
                    {
                        soundManagerPreop.PlayItemSound();
                    }
                    
                    PerformInteraction();
                }
            }
        }

        if (this.gameObject.name != "Bobby" && this.gameObject.name != "document_holder" && this.gameObject.name != "kit_carretera" && this.gameObject.name != "extintor" && this.gameObject.name != "botiquin")
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
        // Aqu� puedes agregar la l�gica de tu funci�n de interacci�n
        if(this.gameObject.name == "ManualOperativo")
        {
            basicsManager.OpenManualCanvas();
        }
        else if(this.gameObject.name == "document_holder")
        {
            basicsManager.OpenDocumentsCanvas();
        }
        else if(this.gameObject.name == "kit_carretera")
        {
            basicsManager.OpenKitCanvas();
        }
        else if(this.gameObject.name == "extintor")
        {
            basicsManager.OpenExtintorCanvas();
        }
        else if(this.gameObject.name == "botiquin")
        {
            basicsManager.OpenBotiquinCanvas();
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

