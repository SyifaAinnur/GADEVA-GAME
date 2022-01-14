using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChildSuriken : MonoBehaviour
{
    public float speed;
    public bool isRotate = false;

    // Start is called before the first frame update
    void Start()
    {
        isRotate = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRotate == true)
        {
            Invoke("Rotate", 0.3f);
        }
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0f, 0f, speed) * Time.deltaTime);
    }
}
