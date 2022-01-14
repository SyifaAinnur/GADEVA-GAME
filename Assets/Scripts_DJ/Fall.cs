using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            SoundManagerDoodle.PlaySound("crack");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 650f);

            animator.SetBool("IsCollide", true);

            Invoke("hilang", 0.2f);

            Invoke("muncul", 0.8f);
            //Invoke("DropPlatform", 0.2f);
            //Destroy(gameObject, 2f);
        }
    }

    void hilang()
    {
        gameObject.SetActive(false);
    }

    void muncul()
    {
        gameObject.SetActive(true);
    }

    /*void DropPlatform()
    {
        rb.isKinematic = false;
    }*/
}
