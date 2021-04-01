using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{

  public bool isActivated = false;
  public GameObject bridge;
  public GameObject BBladder;
  public GameObject Playerladder;

  public void OnInteract()
  {
      isActivated = !isActivated;
      Debug.Log(isActivated);

      if(isActivated)
       {
        bridge.SetActive(true);
        BBladder.SetActive(true);
        Playerladder.SetActive(true);
       }
      else
       {
         bridge.SetActive(false);
         BBladder.SetActive(false);
         Playerladder.SetActive(false);
       }
      
  }
}
