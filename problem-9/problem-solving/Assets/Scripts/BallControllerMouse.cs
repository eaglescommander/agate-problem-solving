using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerMouse : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    public float speed = 20.0f;

    private Rigidbody2D rigidBody2D;
    private Transform transform;

    private Vector3 target;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }
    
    void Update()
    {
        getMouse();
    }

    void FixedUpdate()
    {
        moveBall();
    }

    void getMouse()
    {
        target = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0f;
    }

    void moveBall()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
