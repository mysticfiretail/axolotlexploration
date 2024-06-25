using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTotemF : MonoBehaviour
{
    public bool isActivated = false;
  public GameObject waterfall;
  public GameObject waterspray;

  public void OnInteract()
  {
      isActivated = !isActivated;
      Debug.Log(isActivated);

      if(isActivated)
       {
        waterfall.SetActive(false);
        waterspray.SetActive(false);
       }
      else
       {
         waterfall.SetActive(true);
         waterspray.SetActive(true);
       }
      
  }
}
