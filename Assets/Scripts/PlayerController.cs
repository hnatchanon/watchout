﻿using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerController : MonoBehaviour {

    Vector3 forward;
    Rigidbody rb;
    SphereCollider co;

    public enum playerState { Idle, Running, Claiming, Air, Dead, StageClear, ClaimingStair };

    public Text[] arr_text;

    public Transform head;
    public float speed = 1f;
    public float runningMultiplyer = 2f;
    public float jumpForce = 100f;

    public bool isGroud = false;

    public GameObject result;

    float currentSpeed;

    private playerState state = playerState.Idle;
    private int Score = 0;

    void Start() {
        rb = GetComponent<Rigidbody>();
        co = GetComponent<SphereCollider>();
            result.SetActive(false);
    }

    void Update() {
        forward = new Vector3(head.forward.x, 0, head.forward.z);
        forward = forward / forward.magnitude;


    }

    void FixedUpdate() {
        CheckSpeed();
        CheckInput();
        CheckFall();
        Debug.Log(state);
    }



    public void CheckInput() {
        if (state == playerState.Idle || state == playerState.Air || state == playerState.ClaimingStair) {
            if (Input.GetKey(KeyCode.W)) {
                Move(forward);
            }

            if (Input.GetKey(KeyCode.S))
                Move(new Vector3(-forward.x, 0, -forward.z));

            if (Input.GetKey(KeyCode.A))
                Move(new Vector3(-forward.z, 0, forward.x));

            if (Input.GetKey(KeyCode.D))
                Move(new Vector3(forward.z, 0, -forward.x));
        }
        else if (state == playerState.Claiming) {
            rb.useGravity = false;
            if (Input.GetKey(KeyCode.W))
                Move(new Vector3(forward.x/2, speed/2, forward.z/2));
            else if (Input.GetKey(KeyCode.S)) {
                if (!isGroud)
                    Move(new Vector3(0, -speed/2,0));
                else
                    Move(new Vector3(-forward.x, 0, -forward.z));
            }
            else
                rb.velocity = new Vector3(0, 0, 0);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha2)) && state != playerState.Claiming && state != playerState.Air) {
            state = playerState.Air;
            rb.AddForce(jumpForce * Vector3.up);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    private void Move(Vector3 direction) {
        rb.MovePosition(transform.position + direction * Time.deltaTime * currentSpeed);
    }

    public void CheckSpeed() {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.Alpha5))
            currentSpeed = speed * runningMultiplyer;
        else
            currentSpeed = speed;

        if(state == playerState.ClaimingStair)
        {
            currentSpeed = speed * 3;
        }

        if(state == playerState.Air)
        {
            currentSpeed = speed * 2;
        }
    }

    public void CheckFall() {
        if (transform.position.y <= -50) {
            result.SetActive(true);
            //rb.MovePosition(new Vector3(0, 1, 0));
        }
    }

    public void CollectStar() {
        Score++;
    }

    public void SetState(playerState state) {
        if (this.state == state) {
            return;
        }

        if (state == playerState.Claiming)
        {
            rb.useGravity = false;
        }

        if (this.state == playerState.Claiming) {
            rb.useGravity = true;
        }

        this.state = state;
    }

    public void RestartScene()
    {

        Application.LoadLevel(Application.loadedLevelName);
    }


}