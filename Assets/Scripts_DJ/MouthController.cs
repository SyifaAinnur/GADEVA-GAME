using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthController : MonoBehaviour
{
    //public Rigidbody rb;
    //private Camera cam;

    //Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Input.mousePosition;
        Vector3 mouthposition = Camera.main.WorldToScreenPoint(transform.position);
        mousepos.x = mousepos.x - mouthposition.x;
        mousepos.y = mousepos.y - mouthposition.y;
        float mouthangle = Mathf.Atan2(mousepos.x, mousepos.y) * Mathf.Rad2Deg;
        
        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, mouthangle));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -mouthangle));
        }
    }

    /*void FixedUpdate()
    {
        Vector3 mouse = Input.mousePosition;
        
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        
        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }*/
}
