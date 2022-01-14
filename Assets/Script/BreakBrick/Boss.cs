using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    private Brick brikk;
    private float timer = 0;
    private int step = 0;
    private int gac;
    private bool thinkmove = false;
    private bool changedir = false;

    [SerializeField] GameObject startPanel;
    private void Start()
    {
        brikk = GetComponent<Brick>();
        healthBar.maxValue = brikk.hitToBreak;
        healthBar.value = healthBar.maxValue;
        
    }

    private void Update()
    {
        if (startPanel.activeSelf == false)
        {
            return;
        }
        timer++;
        if(timer > 500f)
        {
            if (!thinkmove) {
                step = 100;
            }
            
            Movement();
        }
    }
    private void Movement()
    {
        
        if(step == 100)
        {
            thinkmove = true;
            gac = Random.Range(0, 2);
            changedir = false;
        }

        switch (gac)
        {
            case 0:
                
                if(step > 0)
                {
                    if (changedir)
                    {
                        transform.parent.Translate(Vector3.right * 0.1f);
                    }
                    else
                    {
                        transform.parent.Translate(Vector3.left * 0.1f);
                    }
                    step--;
                    if (transform.parent.position.x <= -2)
                    {
                        changedir = true;
                    }
                    
                }
                else
                {
                    
                    timer = 0;
                    thinkmove = false;
                }
                break;
            case 1:
                
                if (step > 0)
                {
                    if (changedir)
                    {
                        transform.parent.Translate(Vector3.left * 0.1f);
                    }
                    else
                    {
                        transform.parent.Translate(Vector3.right * 0.1f);
                    }
                    step--;
                    if (transform.parent.position.x >= 2)
                    {
                        changedir = true;
                    }
                }
                else
                {
                    timer = 0;
                    thinkmove = false;
                }
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Ball")
        {
            healthBar.value--;
        }
    }

}
