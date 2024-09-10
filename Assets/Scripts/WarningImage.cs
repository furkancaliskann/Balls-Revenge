using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningImage : MonoBehaviour
{
    Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();

        anim.Play("Warning");

        Destroy(gameObject, 4f);
    }
}
