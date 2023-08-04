using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlertManager : MonoBehaviour
{
    public GameObject alertPanel;
    public TMP_Text alertText, alertTitleText;
    public Image alertImage;
    public void CorrectAlert()
    {
        alertPanel.SetActive(true);
        alertTitleText.text = "¡Bien hecho!";
        alertText.text = "Has elegido la respuesta CORRECTA :D. Sigue así...";
        alertImage.sprite = Resources.Load<Sprite>("images/alertsCheck");
    }

    public void WrongAlert()
    {
        alertPanel.SetActive(true);
        alertTitleText.text = "¡Ups...!";
        alertText.text = "Has elegido la respuesta INCORRECTA. Asegúrate de analizar bien la imagen.";
        alertImage.sprite = Resources.Load<Sprite>("images/alerts_Wrong");
    }

    public void CloseAlert()
    {
        alertPanel.SetActive(false);
    }

}
