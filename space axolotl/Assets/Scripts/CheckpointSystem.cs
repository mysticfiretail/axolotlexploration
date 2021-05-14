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

        if(other.tag == "Bounds" && currentCheckpoint.name =="Bt house")
        {
            player.transform.position = currentCheckpoint.transform.position;
            //BBoop.transform.position = currentCheckpoint.transform.position;
        }
        else if(other.tag == "Bounds")
        {
            player.transform.position = new Vector3(currentCheckpoint.transform.position.x -1,currentCheckpoint.transform.position.y,currentCheckpoint.transform.position.z-1);
            BBoop.transform.position = new Vector3(currentCheckpoint.transform.position.x +2,currentCheckpoint.transform.position.y,currentCheckpoint.transform.position.z+2);
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
    void Update()
    {
        if(!BBoop.GetComponent<BBControlsScript>().isGrounded)
        {
            BBoop.GetComponent<BBControlsScript>().playerVelocity.y += BBoop.GetComponent<BBControlsScript>().gravityValue * Time.deltaTime;
            BBoop.GetComponent<BBControlsScript>().controller.Move(BBoop.GetComponent<BBControlsScript>().playerVelocity * Time.deltaTime);
        }
         if(!player.GetComponent<BBControlsScript>().isGrounded)
        {
            player.GetComponent<NewPlayerControl>().playerVelocity.y += player.GetComponent<NewPlayerControl>().gravityValue * Time.deltaTime;
            player.GetComponent<NewPlayerControl>().controller.Move(player.GetComponent<NewPlayerControl>().playerVelocity * Time.deltaTime);
        }
    }
}
