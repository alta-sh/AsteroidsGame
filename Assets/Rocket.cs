using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float speed = 300.0f;
    public float fireDelay = 0.5f;
    public float fireTime;
    [SerializeField]
    public GameObject bulletObject;
    public int health = 5;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void HandleInput()
    {
        if (Time.time > fireTime + fireDelay)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fireTime = Time.time;
                Instantiate(bulletObject, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey("up"))
            {
                rigidbody.AddForce(transform.up * speed * Time.deltaTime);
            };
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -1) * (speed / 1.5f) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, 1) * (speed / 1.5f) * Time.deltaTime);
        }

        HandleWarping();
    }

    private void HandleWarping()
    {
        if (transform.position.x >= 9.08f)
        {
            transform.position = new Vector2(-9.08f, transform.position.y);
        }
        
        if (transform.position.x <= -9.09f)
        {
            transform.position = new Vector2(9.07f, transform.position.y);
        }

        if (transform.position.y >= 5.35)
        {
            transform.position = new Vector2(transform.position.x, -5.18f);
        }

        if (transform.position.y <= -5.19f)
        {
            transform.position = new Vector2(transform.position.x, 5.34f);
        }
    }
}
