using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bounce : MonoBehaviour
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
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "DoodleJump")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
            {
                SoundManagerDoodle.PlaySound("bounce");
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 650f);
            }
        }
        if (sceneName == "Doodle Jump Wave 2")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
            {
                SoundManagerDoodle.PlaySound("bounce");
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 500f);
            }
        }
        //    if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        //{
        //    SoundManager.PlaySound("bounce");
        //    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 650f);
        //}
        //if (collision.gameObject.name.StartsWith("Player"))
        //{

            //}            

    }
}
