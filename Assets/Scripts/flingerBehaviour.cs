using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flingerBehaviour : MonoBehaviour
{
    private bool mouseHeld = false;
    private Vector3 startPos;
    private LineRenderer lr;
    private Camera cam;
    private GameObject line;
    private Rigidbody rb;

    void Start()
    {
        line = new GameObject();        
        lr = line.AddComponent<LineRenderer>();
        //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.startColor = Color.white;
        lr.endColor = lr.startColor;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;

        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        startPos = gameObject.transform.position;
        line.transform.position = gameObject.transform.position;

        if (Input.GetMouseButton(0))
        {
            if (!mouseHeld)
            {
                mouseHeld = true;
                lr.SetPosition(0, startPos);
            }
            Vector3 mouseCurrentPos = cam.ScreenToWorldPoint(Input.mousePosition);
            lr.SetPosition(0, startPos);
            lr.SetPosition(1, new Vector3(-mouseCurrentPos.x, -mouseCurrentPos.y));
        }
        else if (!Input.GetMouseButton(0) && mouseHeld)
        {
            mouseHeld = false;
            Vector3 mouseEndPos = cam.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(Vector3.Distance(startPos, mouseEndPos));
        }

        if (Input.GetMouseButtonDown(1))
        {
            Launch();
        }
    }

    void Launch()
    {
        rb.velocity = new Vector2(1f, 2f);
    }
}
