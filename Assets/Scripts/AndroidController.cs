using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidController : MonoBehaviour
{
    public GameObject canvas;

    void Start()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            canvas.SetActive(true);
        }
    }
}
