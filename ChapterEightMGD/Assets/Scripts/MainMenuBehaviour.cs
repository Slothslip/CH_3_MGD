using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Load Scene
using TMPro; // show that score

public class MainMenuBehaviour : MonoBehaviour
{

    public TextMeshProUGUI highScoreText;
    //will load a new scene upton being called
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("score", 0);
        GetAndDisplayScore();
    } 
    // Start is called before the first frame update
    void Start()
    {
        // check for a high score and set it to our TMProUGUI
        GetAndDisplayScore();
    }

    private void GetAndDisplayScore()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
