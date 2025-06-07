using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISafeAreaHandler : MonoBehaviour
{
    RectTransform panel; 

    // Start is called before the first frame update
    void Start()
    {
        panel = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        Rect area = Screen.safeArea;

        // pixel size in screen space of the whole screen
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        //set anchor to percentage of the screen
        panel.anchorMin = area.position / screenSize;
        panel.anchorMax = (area.position + area.size) / screenSize;
    }
}
