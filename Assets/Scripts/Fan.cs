using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(0, 0, 5);
    }
}
