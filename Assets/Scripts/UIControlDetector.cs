using UnityEngine;
using UnityEngine.EventSystems;

public class UIControlDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Interactable_Object[] interactableObjects;

    private void Start()
    {
        interactableObjects = FindObjectsOfType<Interactable_Object>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (Interactable_Object obj in interactableObjects)
        {
            obj.OnPointerEnterUI();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (Interactable_Object obj in interactableObjects)
        {
            obj.OnPointerExitUI();
        }
    }
}

