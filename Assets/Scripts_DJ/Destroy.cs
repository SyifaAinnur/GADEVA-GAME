using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPrefab;
    public GameObject breakablePrefab;
    public GameObject movePlatformPrefab;
    private GameObject myPlat;
    public GameObject winPlat;

    private bool spawnPlat = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (winPlat.activeInHierarchy)
        {
            spawnPlat = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Platform") && spawnPlat == true)
        {
            if (Random.Range(1, 7) == 1)
            {
                Destroy(collision.gameObject);

                Instantiate(springPrefab, new Vector2(Random.Range(-6.5f, 6.5f), player.transform.position.y + (8 + Random.Range(0.4f, 0.6f))), Quaternion.identity);

            }

            else if (Random.Range(1, 7) == 2)
            {
                Destroy(collision.gameObject);

                Instantiate(breakablePrefab, new Vector2(Random.Range(-6.5f, 6.5f), player.transform.position.y + (8 + Random.Range(0.4f, 0.6f))), Quaternion.identity);
            }

            else if (Random.Range(1, 7) == 3)
            {
                Destroy(collision.gameObject);

                Instantiate(movePlatformPrefab, new Vector2(Random.Range(-6.5f, 6.5f), player.transform.position.y + (8 + Random.Range(0.4f, 0.6f))), Quaternion.identity);
            }

            else
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-6.5f, 6.5f), player.transform.position.y + (8 + Random.Range(0.4f, 0.6f)));
            }
        }

        else if (collision.gameObject.name.StartsWith("Spring") && spawnPlat == true)
        {
            if (Random.Range(1, 7) == 1)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-6.5f, 6.5f), player.transform.position.y + (8 + Random.Range(0.4f, 0.6f)));

            }
            else
            {
                Destroy(collision.gameObject);

                Instantiate(platformPrefab, new Vector2(Random.Range(-6.5f, 6.5f), player.transform.position.y + (8 + Random.Range(0.4f, 0.6f))), Quaternion.identity);
            }
        }

        else if (collision.gameObject.name.StartsWith("Break") && spawnPlat == true)
        {
            if (Random.Range(1, 7) == 2)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-6.5f, 6.5f), player.transform.position.y + (8 + Random.Range(0.4f, 0.6f)));
            }

            else
            {
                Destroy(collision.gameObject);

                Instantiate(platformPrefab, new Vector2(Random.Range(-6.5f, 6.5f), player.transform.position.y + (8 + Random.Range(0.4f, 0.6f))), Quaternion.identity);
            }
        }

        else if (collision.gameObject.name.StartsWith("movePlatform") && spawnPlat == true)
        {
            if (Random.Range(1, 7) == 3)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-6.5f, 6.5f), player.transform.position.y + (8 + Random.Range(0.4f, 0.6f)));
            }

            else
            {
                Destroy(collision.gameObject);

                Instantiate(platformPrefab, new Vector2(Random.Range(-6.5f, 6.5f), player.transform.position.y + (8 + Random.Range(0.4f, 0.6f))), Quaternion.identity);
            }
        }

        if(collision.gameObject.name.StartsWith("Bullet"))
        {
            Destroy(collision.gameObject);
        }


        /*Destroy(collision.gameObject);


        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        Debug.Log("Created Normal");*/

    }

}
