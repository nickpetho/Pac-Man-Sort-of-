using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script uses keyboard events to move the object.
public class PacManMove : MonoBehaviour
{
    public float speed = 0.01f;
    public bool isCaught = false;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        // Get the Rigidbody component of this object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCaught)
        { 
            // Amount to move in each dimension
            float dx = 0;
            float dy = 0;

            // Input.GetKey(key) returns true if that key is currently down
            // KeyCode.keyname is used for keys that don'w correspond to an ASCII char

            // Move up
            if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
            {
                dy = speed;
                transform.eulerAngles = new Vector3(0, 0, 90);
            }
            // Move down
            if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
            {
                dy = -speed;
                transform.eulerAngles = new Vector3(0, 0, 270);
            }
            // Move left
            if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            {
                dx = -speed;
                transform.eulerAngles = new Vector3(0, 0, 180);
            }
            // Move right
            if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
            {
                dx = speed;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            // Move by that amount
            rb.position += new Vector2(dx, dy);

            void OnCollisionEnter2D(Collision2D col)
            {
                GameObject g = col.gameObject;
                if (g.CompareTag("Enemy"))
                {
                    isCaught = true;
                    Debug.Log(isCaught);
                }
            }
        }
    }
}
