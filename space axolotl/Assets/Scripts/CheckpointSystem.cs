using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{

public GameObject currentCheckpoint;
public GameObject player;
public GameObject BBoop;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Checkpoint")
        {
             currentCheckpoint = other.gameObject;
        }

        if(other.tag == "Bounds")
        {
            player.transform.position = currentCheckpoint.transform.position;
            BBoop.transform.position = currentCheckpoint.transform.position;
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
    void Update()
    {
        
    }
}
