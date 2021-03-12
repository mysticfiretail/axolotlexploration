using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testClimbing : MonoBehaviour
{
public Animator animator;
   void OnTriggerEnter (Collider other)
   {
       if(other.CompareTag("Player"))
       {
           Debug.Log("cehck");
            animator.SetTrigger("isClimbing");
       }

   }

   void OnTriggerExit (Collider other)
   {
       if(other.CompareTag("Player"))
       {
           animator.ResetTrigger("isClimbing");
       }
    
   }
}
