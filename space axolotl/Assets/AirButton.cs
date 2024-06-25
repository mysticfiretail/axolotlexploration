using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirButton : MonoBehaviour
{
    public bool isActive;
    public GameObject Platform;
    void OnTriggerEnter(Collider other)
    {
    isActive = true;

      if(isActive)
       {
         Platform.GetComponent<Platform_Moving>().enabled = true;
       }
      else
       {
         Platform.GetComponent<Platform_Moving>().enabled = false;
       }
    }
    void OnTriggerExit(Collider other)
    {
        isActive = false;
    }

}
