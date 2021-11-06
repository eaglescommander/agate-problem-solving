using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        PushBall();
    }
    
    void PushBall()
    {
        rigidBody2D.AddForce(new Vector2(50, 30));
    }
}
