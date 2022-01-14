using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Rigidbody2D playerRB;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        if (Input.GetKey(KeyCode.W)) playerRB.velocity = Vector3.up * 2;
        else if (Input.GetKey(KeyCode.D)) playerRB.velocity = Vector3.right * 2;
        else if (Input.GetKey(KeyCode.S)) playerRB.velocity = Vector3.down * 2;
        else if (Input.GetKey(KeyCode.A)) playerRB.velocity = Vector3.left * 2;
        else playerRB.velocity = Vector3.zero;
    }
}
