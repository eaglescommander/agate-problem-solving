using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerKeyboard : MonoBehaviour
{
    public float speed = 20.0f;

    private Rigidbody2D rigidBody2D;

    private Vector2 movement;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        getInput();
    }

    void FixedUpdate()
    {
        moveBall();
    }

    void getInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void moveBall()
    {
        rigidBody2D.MovePosition(rigidBody2D.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
