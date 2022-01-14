using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject Obstacle;
    public GameObject Obstacle1;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    private Vector2 lastObstaclePosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            int index = 0;
            while (index < 2)
            {
                Spawn();
                index++;
            }
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        
        while (Vector3.Distance(spawnPosition ,lastObstaclePosition) < 2)
        {
            spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        }
        lastObstaclePosition = spawnPosition;
        
        int randomV = Random.Range(0, 2);


        switch (randomV)
        {
            case 0:
                Instantiate(Obstacle, transform.position + spawnPosition, transform.rotation);
                break;

            case 1:
                Instantiate(Obstacle1, transform.position + spawnPosition, transform.rotation);
                break;

        }
    }
}
