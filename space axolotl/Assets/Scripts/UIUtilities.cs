using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIUtilities : MonoBehaviour
{
    public GameObject player;
    public GameObject BBoop;
    public void LoadScene(string SceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);
    }

    public void RestartCheckpoint()
    {
        player.transform.position = new Vector3(player.GetComponent<CheckpointSystem>().currentCheckpoint.transform.position.x - 1, player.GetComponent<CheckpointSystem>().currentCheckpoint.transform.position.y, player.GetComponent<CheckpointSystem>().currentCheckpoint.transform.position.z - 1);
        BBoop.transform.position = new Vector3(BBoop.GetComponent<CheckpointSystem>().currentCheckpoint.transform.position.x + 2, BBoop.GetComponent<CheckpointSystem>().currentCheckpoint.transform.position.y, BBoop.GetComponent<CheckpointSystem>().currentCheckpoint.transform.position.z + 2);
    }
}

