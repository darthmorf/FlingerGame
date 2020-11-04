using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{ // Update is called once per frame

    [SerializeField] private Transform camera;
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = camera.position.x;
        pos.y = camera.position.y;
        transform.position = pos;
    }
}
