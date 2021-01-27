using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float speed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
