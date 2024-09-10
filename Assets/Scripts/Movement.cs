using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    Rigidbody2D rb;
    float speed = 6f;
    public AndroidButton leftButton, rightButton;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || leftButton.pointerDown) MoveLeft();
        else if (Input.GetKey(KeyCode.RightArrow) || rightButton.pointerDown) MoveRight();
        else StopMoving();
    }

    public void MoveLeft()
    {
        rb.velocity = Vector2.left * speed;
    }

    public void MoveRight()
    {
        rb.velocity = Vector2.right * speed;
    }

    public void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }
}
