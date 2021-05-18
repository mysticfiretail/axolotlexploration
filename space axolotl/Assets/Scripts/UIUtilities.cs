using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIUtilities : MonoBehaviour
{
    public void LoadScene(string SceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);
    }

    public void RestartCheckpoint()
    {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
        CheckpointSystem CS = player.GetComponent<CheckpointSystem>();
        CS.RestartCheckpoint();
       
    }

        public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

