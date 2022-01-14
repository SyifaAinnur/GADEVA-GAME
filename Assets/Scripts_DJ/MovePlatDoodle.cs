using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatDoodle : MonoBehaviour
{
    float dirX, moveSpeed = 5f;
    bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 15f)
            moveRight = false;
        if (transform.position.x < -15f)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            SoundManagerDoodle.PlaySound("bounce");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 650f);
        }
    }
}
