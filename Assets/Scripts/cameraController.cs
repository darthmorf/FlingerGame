using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private float speed = 0.1f;
    private float minFov = 2.5f;
    private float maxFov = 15f;
    private float sensitivity = 10f;
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pos.y -= speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed;
        }

        transform.position = pos;

        float fov = Camera.main.orthographicSize;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.orthographicSize = fov;
    }
}
