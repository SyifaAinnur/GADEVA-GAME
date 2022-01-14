using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDoodle : MonoBehaviour
{
    //public GameObject hitEffect;
    public GameObject platformprefab;
    BossController bossController;

    private void Update()
    {
        Physics2D.IgnoreCollision(platformprefab.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        //if (collision.gameObject.name.StartsWith("Platform"))
        //{
        //    Destroy(gameObject);
        //}
        if (collision.gameObject.name.StartsWith("Frame"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.name.StartsWith("TheDestroyer"))
        {
            Destroy(gameObject);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("BodyBoss"))
        {
            SoundManagerDoodle.PlaySound("explode");
            bossController = FindObjectOfType<BossController>();
            bossController.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
