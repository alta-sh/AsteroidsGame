using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnLocation
{
    TOP_WALL,
    RIGHT_WALL,
    BOTTOM_WALL,
    LEFT_WALL
}

public class SpawnManager : MonoBehaviour
{
    public GameObject Asteroid;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroid());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            SpawnLocation wall = (SpawnLocation)UnityEngine.Random.Range(0, 4);
            Debug.Log(wall.ToString());

            switch (wall)
            {
                case SpawnLocation.TOP_WALL:
                    Vector2 spawnLocationTop = new Vector2(UnityEngine.Random.Range(-2.0f, 2.0f), 6);
                    Instantiate(Asteroid, spawnLocationTop, Quaternion.Euler(0, 0, 180));
                    break;
                case SpawnLocation.RIGHT_WALL:
                    Vector2 spawnLocationRight = new Vector2(10, UnityEngine.Random.Range(-3.0f, 3.0f));
                    Instantiate(Asteroid, spawnLocationRight, Quaternion.Euler(0, 0, -270));
                    break;
                case SpawnLocation.BOTTOM_WALL:
                    Vector2 spawnLocationBottom = new Vector2(UnityEngine.Random.Range(-2.0f, 2.0f), -6);
                    Instantiate(Asteroid, spawnLocationBottom, Quaternion.Euler(0, 0, 0));
                    break;
                case SpawnLocation.LEFT_WALL:
                    Vector2 spawnLocationLeft = new Vector2(-10, UnityEngine.Random.Range(-3.0f, 3.0f));
                    Instantiate(Asteroid, spawnLocationLeft, Quaternion.Euler(0, 0, -90));
                    break;
            }

            yield return new WaitForSeconds(3.5f);
        }
    }
}
