using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button6 : MonoBehaviour
{
    public bool isActive;

    void OnTriggerEnter(Collider other)
    {
        isActive = true;
    }
    void OnTriggerExit(Collider other)
    {
        isActive = false;
    }

    void Update()
    {
        
    }
}
