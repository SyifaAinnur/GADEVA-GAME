using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speeddrop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, -1) * Time.deltaTime * speeddrop);
        if(transform.position.y < -7f){
            Destroy(gameObject);
        }
    }
}
