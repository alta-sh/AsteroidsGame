using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float speed = 100.0f;
    private bool isBreakable = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(transform.up * speed);
        int ranResult = UnityEngine.Random.Range(0, 100); 
        if (ranResult < 40) // 40% change of it being breakable
        {
            isBreakable = true;
            transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z);
            speed /= 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision);
            if (isBreakable)
            {
                for (int i = 0; i < (int)UnityEngine.Random.Range(2, 3); i++)
                {
                    GameObject miniAsteroids = this.gameObject;
                    miniAsteroids.transform.localScale = new Vector3(this.gameObject.transform.localScale.x / 1.5f, this.gameObject.transform.localScale.y / 1.5f, 0);
                    miniAsteroids.GetComponent<Asteroid>().speed *= 2;
                    miniAsteroids.GetComponent<BoxCollider2D>().enabled = true;
                    Instantiate(miniAsteroids, transform.position, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, -360)));
                    miniAsteroids.GetComponent<Asteroid>().isBreakable = false;
                }
            }
            Destroy(this.gameObject);
        }

        if (collision.tag == "Rocket")
        {
            GameObject.FindGameObjectWithTag("Rocket").GetComponent<Rocket>().DecreaseHealth();
            Destroy(this.gameObject);
        }
    }
}
