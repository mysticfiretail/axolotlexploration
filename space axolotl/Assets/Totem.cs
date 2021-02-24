using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{

  public bool isActivated = false;
  public GameObject bridge;

  public void OnInteract()
  {
      isActivated = !isActivated;
      Debug.Log(isActivated);

      if(isActivated)
       {
        bridge.SetActive(true);
       }
      else
       {
         bridge.SetActive(false);
       }
      
  }
}
