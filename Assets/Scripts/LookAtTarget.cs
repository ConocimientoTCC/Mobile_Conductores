using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform defaultTarget;
    public Transform target;
    public float minDist = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (target != null) 
        {
            if(distance < minDist)
            {
                transform.LookAt(target);
            }
            else
            {
                transform.LookAt(defaultTarget);
            }
            
        }
    }
}
