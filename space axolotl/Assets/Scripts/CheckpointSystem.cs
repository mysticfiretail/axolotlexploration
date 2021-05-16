using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{

public GameObject currentCheckpoint;
    public Vector3 currentCheckpointPosition;
public GameObject player;
public GameObject BBoop;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Checkpoint")
        {
             currentCheckpoint = other.gameObject;
            currentCheckpointPosition = currentCheckpoint.transform.position;
        }

        if(other.tag == "Bounds" && currentCheckpoint.name =="Bt house")
        {
            player.transform.position = currentCheckpoint.transform.position;
            //BBoop.transform.position = currentCheckpoint.transform.position;
        }
        else if(other.tag == "Bounds")
        {
            RestartCheckpoint();
        }
    }

    void OnTriggerExit(Collider other)
    {

    }

    void Start()
    {
        currentCheckpointPosition = gameObject.transform.position;
    }
    void Update()
    {
        if(!BBoop.GetComponent<BBControlsScript>().isGrounded)
        {
            BBoop.GetComponent<BBControlsScript>().playerVelocity.y += BBoop.GetComponent<BBControlsScript>().gravityValue * Time.deltaTime;
            BBoop.GetComponent<BBControlsScript>().controller.Move(BBoop.GetComponent<BBControlsScript>().playerVelocity * Time.deltaTime);
        }
         if(!player.GetComponent<NewPlayerControl>().isGrounded)
        {
            player.GetComponent<NewPlayerControl>().playerVelocity.y += player.GetComponent<NewPlayerControl>().gravityValue * Time.deltaTime;
            player.GetComponent<NewPlayerControl>().controller.Move(player.GetComponent<NewPlayerControl>().playerVelocity * Time.deltaTime);
        }
    }
    public void RestartCheckpoint()
    {
        CheckpointSystem playerCS = player.GetComponent<CheckpointSystem>();
        CheckpointSystem BBoopCS = BBoop.GetComponent<CheckpointSystem>();
        //Debug.Log("restart checkpoint method called");
        player.transform.position = new Vector3(playerCS.currentCheckpointPosition.x - 1,
            playerCS.currentCheckpointPosition.y,
            playerCS.currentCheckpointPosition.z - 1);
        BBoop.transform.position = new Vector3(BBoopCS.currentCheckpointPosition.x + 2,
            BBoopCS.currentCheckpointPosition.y,
            BBoopCS.currentCheckpointPosition.z + 2);
    }
}
