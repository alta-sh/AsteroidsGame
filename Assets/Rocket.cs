using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float speed = 300.0f;

    [SerializeField]
    public GameObject bulletObject;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }


    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletObject, new Vector2(transform.position.x, transform.position.y), transform.rotation);
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
    }
}
