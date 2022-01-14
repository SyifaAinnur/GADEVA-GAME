using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedneeded;
    public bool inPlay;
    public Transform paddle;
    public Transform particle;
    public GameManager gm;
    public Transform powerup;
    private int bouncecount;
    private float Timer = 0;

    private Vector2 LastPost;
    private float LastPostY;
    AudioSource audio;

    [SerializeField] GameObject startPanel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        // rb.AddForce(Vector2.up * speedneeded);
    }

    // Update is called once per frame
    void Update()
    {

        if (gm.gameover == true)
        {
            return;
        }
        if (inPlay == false)
        {

            transform.position = paddle.position;
        }
        else 
        {
            if (rb.velocity.magnitude > speedneeded)
            {
                rb.velocity = rb.velocity.normalized * speedneeded;
            }
            else if (rb.velocity.magnitude < speedneeded)
            {
                rb.velocity = rb.velocity.normalized * speedneeded;
            }
        }

        if (Input.GetButtonDown("Jump") && !inPlay && startPanel.activeSelf == false)
        {
            
            inPlay = true;
            rb.velocity = (Vector2.up * speedneeded);
        }


        /*if(Timer > 5)
        {
            if(Vector2.Distance(LastPost, transform.position)<= 0.1)
            {
                rb.velocity *= 2; 
            }

            Timer = 0;
        }
        else
        {
            LastPost = transform.position;
            Timer += Time.deltaTime;
        }*/
        Debug.Log(rb.velocity.magnitude);
        // Debug.Log("inplay " + inPlay);
    }



    //wat hapen kalau kena trigger bawah
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bottom"))
        {
            // Debug.Log("bola masuk bawah");
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }
    }

    //wat happen kalau nabrak box
    void OnCollisionEnter2D(Collision2D other)
    {
        // CheckVelocity();
        // if (other.transform.CompareTag("paddle"))
        // {

        //     if (rb.velocity.x <= 0.1f)
        //     {
        //         Debug.Log("bismillah" + (transform.position.x - other.transform.position.x * 4));
        //         rb.velocity = new Vector2((transform.position.x - other.transform.position.x) * 4, rb.velocity.y);
        //     }
        // }
        if (other.transform.CompareTag("brick"))
        {
            //baru sampe sini
            Brick brick = other.gameObject.GetComponent<Brick>();
            if (brick.hitToBreak > 1)
            {
                brick.BreakBrick();
            }

            else
            {
                int randomChance = Random.Range(0, 100);
                if (randomChance < 10)
                {
                    Instantiate(powerup, other.transform.position, other.transform.rotation);
                }

                //manggil partikel
                Transform newParticle = Instantiate(particle, other.transform.position, other.transform.rotation);

                //agar gak berbekas tambah transform newparticle
                Destroy(newParticle.gameObject, 2.5f);

                gm.UpdateScore(brick.points);
                gm.UpdateNumberOfBrick();
                if (other.collider.name == "Boss")
                {

                    Destroy(other.collider.transform.parent.gameObject);
                }
                else
                {
                    Destroy(other.gameObject);
                }
            }
            audio.Play();
        }

    }
    public void CheckVelocity()
    {
        // Debug.Log("123 '  '" + rb.velocity);
        //Vector2 velX =  new Vector2(rb.velocity.x, 0);
        //Vector2 velY = new Vector2(0, rb.velocity.y);

        // if (Vector2.Distance(velX,velY ) < 6) 
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + speedneeded);
        // }
        // if (rb.velocity.x < 5 && rb.velocity.x > -5 && rb.velocity.y < 5 && rb.velocity.y > -5)
        // {
        //     float result = 6 - Vector2.Distance(velX, velY);
        //     rb.velocity = new Vector2(rb.velocity.x + (result / 2), rb.velocity.y + (result / 2));
        // }



        // transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Vector2.Distance(transform.position, other.position) * 2, transform.GetComponent<Rigidbody2D>().velocity.y);

        // Prevent ball from rolling in the same directon forever
        // if (rb.velocity.x == 0)
        // {

        //     bouncecount++;
        //     if(bouncecount >= 1)
        //     {
        //         if (Random.Range(0,2) == 0) {
        //             rb.velocity = new Vector2(2, rb.velocity.y);
        //         }
        //         else
        //         {
        //             rb.velocity = new Vector2(-2, rb.velocity.y);
        //         }
        //         bouncecount = 0;
        //     }
        // }

        if (bouncecount == 0)
        {
            LastPostY = transform.position.y;
            bouncecount++;

        }
        else
        {
            if (LastPostY == transform.position.y)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 2);

            }
            bouncecount = 0;
        }
        /*if (rb.velocity.y == 0)
        {

            bouncecount++;
            if (bouncecount >= 2)
            {
                // if(Random.Range(0, 2) == 0)
                // {
                //     rb.velocity = new Vector2(rb.velocity.x, 2);
                // }
                // else
                // {
                //     rb.velocity = new Vector2(rb.velocity.x, -2);
                // }
                
            }

        }
        else
        {
            bouncecount = 0;
        }*/
    }
}
