using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{

  public bool isActivated = false;

  public void OnInteract()
  {
      isActivated = !isActivated;
      Debug.Log(isActivated);
  }
}
