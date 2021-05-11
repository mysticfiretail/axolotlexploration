using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTotemF : MonoBehaviour
{
   public bool isActivated = false;
  public GameObject stairs;

  public void OnInteract()
  {
      isActivated = !isActivated;
      Debug.Log(isActivated);

      if(isActivated)
       {
        stairs.SetActive(true);
       }
      else
       {
         stairs.SetActive(false);
       }
      
  }
}
