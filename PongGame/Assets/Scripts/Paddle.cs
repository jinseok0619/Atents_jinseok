using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    public Rigidbody2D rb;

    private float movement;

    void Start()
    {
        
    }

    void Update()
    {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Paddle1");
        }
        else
        {
            movement = Input.GetAxisRaw("Paddle2");
        }

        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }
}
