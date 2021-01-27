using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float speed;
    private bool isBreakable = false;
    private bool isMini = false;
    public GameObject miniAsteroids;

    [SerializeField]
    private Text scoreText;

    void Start()
    {
        
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(transform.up * speed);
        int ranResult = UnityEngine.Random.Range(0, 100); 
        if (ranResult < 35 && !isMini) // 35% chance of it being breakable
        {
            isBreakable = true;
            transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z);
            speed /= 2;
        }
    }

    private void Awake()
    {
        speed = UnityEngine.Random.Range(100f, 200f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            GameObject.FindGameObjectWithTag("Rocket").GetComponent<Rocket>().score += 5;
            scoreText.text = "Score: " + GameObject.FindGameObjectWithTag("Rocket").GetComponent<Rocket>().score.ToString();
            Destroy(collision);
            if (isBreakable)
            {
                for (int i = 0; i < (int)UnityEngine.Random.Range(2, 3); i++)
                {
                    miniAsteroids.transform.localScale = new Vector3(this.gameObject.transform.localScale.x / 1.5f, this.gameObject.transform.localScale.y / 1.5f, 0);
                    miniAsteroids.GetComponent<PolygonCollider2D>().enabled = true;
                    Instantiate(miniAsteroids, transform.position, Quaternion.Euler(0, 0, UnityEngine.Random.Range(-360, 360)));
                    miniAsteroids.GetComponent<Asteroid>().isMini = true;
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
