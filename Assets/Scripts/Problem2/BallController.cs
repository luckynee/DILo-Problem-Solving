﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public UnityEvent OnGetResource;
    public float speed = 5f;

    private Vector2 inputVector = Vector2.zero;

    Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inputVector = GetDirection();
            MoveCircle(inputVector, speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Resource")
        {
            Destroy(collision.gameObject);
            OnGetResource.Invoke();
            Debug.Log("Get Resource");
        }
    }

    private void MoveCircle(Vector2 input, float velocity)
    {
        rb2d.velocity = input * velocity;
    }

    public Vector2 GetDirection()
    {
        Debug.Log("Clicked");
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z));
        Vector3 direction = worldMousePosition - this.transform.position;
        direction.Normalize();
        return (Vector2)direction;
    }
}
