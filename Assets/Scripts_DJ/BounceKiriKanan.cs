using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceKiriKanan : MonoBehaviour
{
    //public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().position.x > 0) 
        {
            SoundManagerDoodle.PlaySound("bounce");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 2000f);
        }
        if (collision.gameObject.GetComponent<Rigidbody2D>().position.x < 0)
        {
            SoundManagerDoodle.PlaySound("bounce");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 2000f);
        }

        //if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
        //{
        //    SoundManager.PlaySound("bounce");
        //    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 650f);
        //}

        //if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x >= 0)
        //{
        //    SoundManager.PlaySound("bounce");
        //    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 650f);
        //}
        //if (collision.gameObject.name.StartsWith("Player"))
        //{

        //}            

    }
}
