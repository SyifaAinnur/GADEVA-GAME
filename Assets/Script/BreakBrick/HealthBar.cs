using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    private Brick brikk;

    // Start is called before the first frame update
    void Start()
    {
        brikk = GetComponent<Brick>();
        healthBar.maxValue = brikk.hitToBreak;
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Ball")
        {
            healthBar.value--;
        }
    }
}
