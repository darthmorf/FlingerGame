using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catPointer : MonoBehaviour
{
    [SerializeField] private GameObject cat;
   
    void Update()
    {
        Vector3 targetLocation = Camera.main.WorldToScreenPoint(cat.transform.position);
        Vector3 toTarget = targetLocation - transform.position;
        Vector3 rotatedToTarget = Quaternion.Euler(0, 0, 360) * toTarget;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, rotatedToTarget);

        transform.rotation = targetRotation;
    }
}
