using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetBehaviour : MonoBehaviour
{
    private GameObject line;
    private LineRenderer lr;
    private float radius = 3f;

    void Start()
    {        
        lr = gameObject.AddComponent<LineRenderer>();
        lr.transform.position = transform.position;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.white;
        lr.startWidth = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        DrawAtmosphere();
        DoSpacePhysics();
    }

    void DrawAtmosphere()
    {
        int segments = 360;
        int pointCount = segments + 1;
        lr.positionCount = pointCount;
        Vector3[] points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius) + transform.position;
        }

        lr.SetPositions(points);
    }

    void DoSpacePhysics()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Gravity");

        foreach (GameObject go in gameObjects)
        {
            float dist = Vector2.Distance(gameObject.transform.position, go.transform.position);
            if (dist <= radius) // Within 'atmosphere'
            {
                if (go.name == "Flingee")
                    Debug.Log(dist - gameObject.GetComponent<CircleCollider2D>().radius);
                go.GetComponent<Rigidbody2D>().AddForce(transform.position - go.transform.position);
            }
        }
    }
}
