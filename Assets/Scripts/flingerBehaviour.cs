﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flingerBehaviour : MonoBehaviour
{
    private LineRenderer lr;
    private Camera cam;
    private GameObject line;
    private Rigidbody2D rb;

    private Vector2 launchVelocity = new Vector2(2f, 4f);
    public bool space = true;

    void Start()
    {
        line = new GameObject();        
        lr = line.AddComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(0.5f, 0.0f), new GradientAlphaKey(0f, 1f) }
        );
        lr.colorGradient = gradient;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.01f;

        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        line.transform.position = gameObject.transform.position;

        if (Input.GetMouseButton(0) && gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f)
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            launchVelocity = ((Vector2) transform.position - mousePos) * 2;

            drawArc();
        }
        else if (!Input.GetMouseButton(0))
        {
            lr.enabled = false;
        }

        if (Input.GetMouseButtonUp(0) && rb.IsSleeping())
        {
            Launch();
        }
    }

    void Launch()
    {
        rb.velocity = launchVelocity;    
    }    

    Vector2 calculatePosition(float elapsedTime)
    {
        Vector2 pos = gameObject.transform.position;
        return Physics2D.gravity * elapsedTime * elapsedTime * 0.5f + launchVelocity * elapsedTime + pos;
    }

    void drawArc()
    {
        lr.enabled = true;
        int pointCount = 25;
        lr.SetPosition(0, gameObject.transform.position);
        lr.positionCount = pointCount;
        for (int i = 1; i < pointCount; i++)
        {
            lr.SetPosition(i, calculatePosition(0.05f * i));
        }        
    }
}
