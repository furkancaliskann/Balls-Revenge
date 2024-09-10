using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Performance : MonoBehaviour
{
    Settings settings;

    public float updateInterval = 0.5f; //How often should the number update

    float accum = 0.0f;
    int frames = 0;
    float timeleft;
    float fps;

    GUIStyle textStyle = new GUIStyle();

    // Use this for initialization
    void Start()
    {
        settings = GetComponent<Settings>();

        timeleft = updateInterval;

        textStyle.fontSize = 38;
        textStyle.fontStyle = FontStyle.Bold;
        textStyle.normal.textColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (!settings.isFpsCounterOn) return;

        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        // Interval ended - update GUI text and start new interval
        if (timeleft <= 0.0)
        {
            // display two fractional digits (f2 format)
            fps = (accum / frames);
            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;
        }
    }

    void OnGUI()
    {
        if (!settings.isFpsCounterOn) return;

        //GUI.Label(new Rect(Screen.width - 100, 10, 100, 25), fps.ToString("F2") + "FPS", textStyle);

        GUI.Label(new Rect(Screen.width - 205, 10, 100, 25), fps.ToString("F2") + "FPS", textStyle);
    }
}
