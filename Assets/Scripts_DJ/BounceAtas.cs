using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAtas : MonoBehaviour
{
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
        SoundManagerDoodle.PlaySound("bounce");
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.down * 100f);
    }
}
