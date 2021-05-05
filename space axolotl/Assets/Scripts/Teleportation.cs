using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    // Start is called before the first frame update
   public Transform teleportTarget;
   public GameObject player;

   public GameObject BBplayer;

   void OnTriggerEnter (Collider other)
   {
       if (gameObject.tag == "single" && other.tag =="Player")
       {
            Debug.Log("check");
            player.transform.position = teleportTarget.transform.position;
            Debug.Log("done");
       }
       else if (gameObject.tag == "single" && other.tag =="BBPlayer")
       {
            Debug.Log("check");
            BBplayer.transform.position = teleportTarget.transform.position;
            Debug.Log("done");
       }
       

       if(gameObject.tag =="both")
       {
            Debug.Log("check");
            player.transform.position = teleportTarget.transform.position;
            BBplayer.transform.position = teleportTarget.transform.position;
            Debug.Log("done");
       }
   }
}
