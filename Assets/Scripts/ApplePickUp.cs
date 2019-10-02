using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        DestroyGameObject();  
    }
}
