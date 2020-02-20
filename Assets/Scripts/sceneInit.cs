using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneInit : MonoBehaviour
{
    public Vector3 gravity;
    void Start()
    {
        Physics2D.gravity = gravity;
    }

  
}
