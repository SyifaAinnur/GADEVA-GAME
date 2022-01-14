using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapKanan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-18.3f, collision.gameObject.transform.position.y, -.5f);
        }
    }
}
