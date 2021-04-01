using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemLadder : MonoBehaviour
{
    public bool isActivated = false;
  public GameObject Ladder1;
  public GameObject Ladder2;

  public void OnInteract()
  {
      isActivated = !isActivated;
      Debug.Log(isActivated);

      if(isActivated)
       {
        Ladder1.SetActive(true);
        Ladder2.SetActive(true);
       }
      else
       {
         Ladder1.SetActive(false);
         Ladder2.SetActive(false);
       }
      
  }
}
