using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDamage : MonoBehaviour
{
    public float health = 20f;
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        float strength = collision.relativeVelocity.magnitude;

        if (strength > 5)
        {
            health -= strength;
        }

        if (health <= 0)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
                child.parent = null;
            }
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        
    }
}
