using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTotem : MonoBehaviour
{
  public bool isActivated = false;
  public GameObject Platform;
  public GameObject BBladder;
  public GameObject Playerladder;

  public void OnInteract()
  {
      isActivated = !isActivated;
      Debug.Log(isActivated);

      if(isActivated)
       {
         Platform.GetComponent<Platform_Moving>().enabled = true;
       }
      else
       {
         Platform.GetComponent<Platform_Moving>().enabled = false;
       }
    }
}
