using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    PlayerControls Controls;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    bool pausePressed;

    private void Awake()
    {
        Controls = new PlayerControls();

        Controls.Player.Menu.performed += ctx =>
        {

            pausePressed = ctx.ReadValueAsButton();
            if (pausePressed)
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    private void OnEnable()
    {
        Controls.Player.Enable();
    }

    private void OnDisable()
    {
        Controls.Player.Disable();
    }
}
