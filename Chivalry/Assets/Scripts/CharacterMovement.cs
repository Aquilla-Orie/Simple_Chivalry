using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    [SerializeField]
    float speed;

    CharacterController characterController;
    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        camera = transform.Find("Main Camera").GetComponent<Camera>();
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        var movX = Input.GetAxisRaw("Horizontal");
        var movZ = Input.GetAxisRaw("Vertical");

        Vector3 movementVector = (movZ * transform.forward + transform.right * movX).normalized;

        characterController.Move(movementVector * speed * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        camera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
}
