using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

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


    // Update is called once per frame
}
