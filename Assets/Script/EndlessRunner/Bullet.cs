using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [HideInInspector] public Transform player;



    private void Update()
    {
        if (Vector3.Distance(player.position, transform.position) > 20) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Boss")
        {
            collision.GetComponent<boss>().kenaHatimu();
            Destroy(this.gameObject);
        }
    }
}
