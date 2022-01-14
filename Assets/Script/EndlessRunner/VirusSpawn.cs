using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawn : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Rigidbody2D>().velocity = Vector3.left * 2000 * Time.deltaTime;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Side Borders")
        {
            Destroy(this.gameObject);
        }

        else if (collision.tag == "Player")
        {
            PlayerEndless pe = collision.GetComponent<PlayerEndless>();
            pe.StartCoroutine(pe.KenaTembak());
            Destroy(this.gameObject);

        }
    }

   
   
}
