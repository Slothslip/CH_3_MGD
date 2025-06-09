using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Load Scene

public class PauseScreenBehaviour : MainMenuBehaviour
{

    [Tooltip("Reference to the on screen controls menu")]
    public GameObject onScreenControls; 

    // If our game is currently paused 
    public static bool paused;

    [Tooltip("Reference to the pause menu object to turn on/off")]
    public GameObject pauseMenu;

    // restarting the game 
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // will turn our pause menu on or off
    public void SetPauseMenu(bool isPaused)
    {
        paused = isPaused;

        // if the game is pause, timeScale is 0
        Time.timeScale = (paused) ? 0 : 1;

        //pauseMenu.SetActive(paused);
        if (paused)
        {
            SlideMenuIn(pauseMenu);
        }
        else
        {
            SlideMenuOut(pauseMenu);
        }

        onScreenControls.SetActive(!paused);
    }
    // Start is called before the first frame update
    void Start()
    {
        // must be reset in start or else game will be paused upon restart
        SetPauseMenu(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
