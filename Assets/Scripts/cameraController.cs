using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private float speed = 0.1f;
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
    }
}
