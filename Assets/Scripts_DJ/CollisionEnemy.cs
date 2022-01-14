using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemy : MonoBehaviour
{

    private DamageFlickerPlayer damageFlicker;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HealthTextScript.healthAmount -= 1;
            FindObjectOfType<HealthTextScript>().text.text = HealthTextScript.healthAmount.ToString();
            damageFlicker = FindObjectOfType<DamageFlickerPlayer>();
            damageFlicker.TakeDamage();
            Destroy(collision.gameObject);
            if (HealthTextScript.healthAmount <= 0)
            {
                FindObjectOfType<Controller>().GameOver();
            }
        }
    }
}
