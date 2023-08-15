using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoMec_Collider : MonoBehaviour
{
    public BasicsManager basicsManager;
    public AudioSource pickupSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && this.gameObject.name == "EstadoMec_Collider")
        {
            pickupSound.Play();
            basicsManager.OpenMecanicoCanvas();
        }

        else if(other.tag == "Player" && this.gameObject.name == "Level2")
        {
           basicsManager.LoadLevelBtn(2);
        }
    }
}
