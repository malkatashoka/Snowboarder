using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;

    Rigidbody2D rigidBody2D;
    SurfaceEffector2D surfaceEffector2D;

    public bool canMove = true;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
        else
        {
            DisableControls();
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        { 
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidBody2D.AddTorque(-torqueAmount);
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
}
