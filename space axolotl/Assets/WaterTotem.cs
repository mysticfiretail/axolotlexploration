using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTotem : MonoBehaviour
{
    public GameObject platformPiece;
    public float numRotations;
    public bool isCorrect;
    private bool isActive;
    private float curRotations = 0;

    IEnumerator RotateMe(Vector3 byAngles, float inTime) 
     {    var fromAngle = platformPiece.transform.rotation;
         var toAngle = Quaternion.Euler(platformPiece.transform.eulerAngles + byAngles);
         for(var t = 0f; t < 1; t += Time.deltaTime/inTime) 
         {
             platformPiece.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
             yield return null;
         }
         isActive = false;
         curRotations++;
     }

    public void OnInteract()
    {
        if (!isActive)
        {
            isActive = true;
            StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));
        }
    }

    void Update ()
    {
        if (curRotations == numRotations)
        {
            isCorrect = true;
        }
        else{
            isCorrect = false;
        }

        if (curRotations >= 4)
        {
            curRotations = 0;
        }
    }
}
