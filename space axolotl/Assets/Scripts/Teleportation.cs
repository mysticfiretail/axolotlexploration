using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    // Start is called before the first frame update
   public Transform teleportTarget;
   public GameObject player;

   void OnTriggerEnter (Collider other)
   {
       Debug.Log("check");
       other.transform.position = teleportTarget.transform.position;
       Debug.Log("done");
   }
}
