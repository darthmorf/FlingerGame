using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winChecker : MonoBehaviour
{

    private List<GameObject> dogs = new List<GameObject>();
    private bool won = false;

    [SerializeField] private Canvas canvas;

    void Start()
    {
        canvas.enabled = false;
        GameObject[] gos = FindObjectsOfType(typeof(GameObject)) as GameObject[]; //will return an array of all GameObjects in the scene
        foreach (GameObject go in gos)
        {
            if (go.layer == 8)
            {
                dogs.Add(go);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject dog in dogs)
        {
            if (dog != null || won)
                return;
        }

        won = true;
        canvas.enabled = true;
    }
}
