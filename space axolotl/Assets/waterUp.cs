using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterUp : MonoBehaviour
{
     [SerializeField] [Range(0f,10f)] float lerpTime;
    int posIndex = 0;
    int length;
    float t =0f;
   [SerializeField] public GameObject waterTerrain;
    [SerializeField] public GameObject End;
    void Update()
    {
        transform.position = Vector3.Lerp (transform.position, End.transform.position, lerpTime *Time.deltaTime);
    t = Mathf.Lerp(t, 1f, lerpTime* Time.deltaTime);
        if(t>.9f)
            {
            t = 0f;
            posIndex++;
            posIndex = (posIndex >= length) ? 0 : posIndex; 
            
            }

    }
}
