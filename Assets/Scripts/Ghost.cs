using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script moves the object to another object with a given tag ("target" by default,
// but can be changed in the script properties)
public class Ghost : MonoBehaviour
{

    Rigidbody2D rb; // Rigidbody physics component

    public string ChaseTag = "Player";
    public string HomeTag = "Respwan";
    public float speed = 0.0075f;
    public float closeEnough = 0.01f;
    public bool chasing = true;

    void Start()
    {
        // Get the Rigidbody component of this object
        rb = GetComponent<Rigidbody2D>();
    }

    // Move towards location of target object
    void Update()
    {
        if (chasing)
        {
            // Get the target object with this tag
            GameObject targetObject = GameObject.FindWithTag(ChaseTag);

            // If object not found, this will be null. Exit to prevent error.
            if (targetObject == null)
            {
                return;
            }

            // Get its Rigidboy component so can get its position
            Rigidbody2D targetRb = targetObject.GetComponent<Rigidbody2D>();

            // Get difference between current and target location 
            Vector2 delta = targetRb.position - rb.position;

            // If close enough to target stop
            if (delta.magnitude < closeEnough)
            {
                return;
            }

            // Normalize to 1 
            delta.Normalize();

            // Multiply be speed
            delta = delta * speed;

            // Use this to change position
            rb.position += delta;

            void OnTriggerEnter2D(Collider2D col)
            {
                GameObject g = col.gameObject;
                if (g.CompareTag("Key"))
                {
                    chasing = false;
                }
            }
        }

        if (!chasing)
        {
            // Get the target object with this tag
            GameObject targetObject = GameObject.FindWithTag(ChaseTag);

            // If object not found, this will be null. Exit to prevent error.
            if (targetObject == null)
            {
                return;
            }

            // Get its Rigidboy component so can get its position
            Rigidbody2D targetRb = targetObject.GetComponent<Rigidbody2D>();

            // Get difference between current and target location 
            Vector2 delta = targetRb.position - rb.position;

            // If close enough to target stop
            if (delta.magnitude < closeEnough)
            {
                return;
            }

            // Normalize to 1 
            delta.Normalize();

            // Multiply be speed
            delta = delta * speed;

            // Use this to change position
            rb.position += delta;

            void OnCollisionEnter2D(Collider2D col)
            {
                GameObject g = col.gameObject;
                if (g.CompareTag("Respwan"))
                {
                    chasing = true;
                }
            }
        }
    }
}
