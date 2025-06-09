using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Load Scene
using TMPro; // show that score

public class MainMenuBehaviour : MonoBehaviour
{

    public TextMeshProUGUI highScoreText;
    //will load a new scene upton being called
    public GameObject controlPanel;

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
        /* Unpause the game if needed */
        Time.timeScale = 1;

        // check for a high score and set it to our TMProUGUI
        GetAndDisplayScore();

        // slide in the Panel with all the goodies
        SlideMenuIn(controlPanel);
    }

    private void GetAndDisplayScore()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // will move an object from the left side of the screen to the center
    // param name= "obj"> The UI element we would like to move
    public void SlideMenuIn(GameObject obj)
    {
        obj.SetActive(true);

        var rt = obj.GetComponent<RectTransform>();

        if (rt)
        {
            //Set the objects position offscreen
            var pos = rt.position;
            pos.x = -Screen.width / 2;
            rt.position = pos;

            // move the object to the center of the screen (x of 0 is centered)
            //LeanTween.moveX(rt, 0, 1.5f).setEase(LeanTweenType.easeInOutExpo);
            var tween = LeanTween.moveX(rt, 0, 1.5f);
            tween.setEase(LeanTweenType.easeInOutExpo);
            tween.setIgnoreTimeScale(true);
        }
    }

    // will move an object to the right offscreen
    public void SlideMenuOut(GameObject obj)
    {
        var rt = obj.GetComponent<RectTransform>();

        if (rt)
        {
            var tween = LeanTween.moveX(rt, Screen.width / 2, 0.5f);

            tween.setEase(LeanTweenType.easeOutQuad);
            tween.setIgnoreTimeScale(true);

            tween.setOnComplete(() => { obj.SetActive(false);
            });
        }
    }
}
