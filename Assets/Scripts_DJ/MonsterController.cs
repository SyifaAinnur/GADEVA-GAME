using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;
    float moveSpeed = 10f;
    Vector3 directionToTarget;
    public GameObject uglyBee;
    //public GameObject panel;
    //public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        //moveSpeed = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                //Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
                
                target = null;
                break;

            case "Bullet":
                //Instantiate(explosion, transform.position, Quaternion.identity);
                //KillsCounter.killsNumber += 1;
                SoundManagerDoodle.PlaySound("explode");
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            
            case "CollisionEnemy":
                target = null;
                break;
        }
    }

    void MoveEnemy()
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }
        else
            rb.velocity = Vector3.zero;
    }

    public void DestroyEnemy()
    {
        Destroy(uglyBee);
    }
}
