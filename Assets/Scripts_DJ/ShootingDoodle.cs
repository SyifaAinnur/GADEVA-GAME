using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDoodle : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 80f;

    private bool isStarted = false;
    private bool allowShoot = false;

    public GameObject panel;

    [SerializeField] GameObject startPanel;
    // Update is called once per frame
    void Update()
    {
        Debug.Log("1"+startPanel.activeSelf);
        Debug.Log("3"+isStarted);
        if (Input.GetKeyDown(KeyCode.Space) && isStarted == false && startPanel.activeSelf == false)
        {
            if (PauseMenu.isPause == true)
            {
                isStarted = false;
                allowShoot = false;
            }
            if (PauseMenu.isPause == false)
            {
                isStarted = true;
                allowShoot = true;
            }

        }

        if (PauseMenu.isPause == false ) 
        {
            if (Input.GetButtonDown("Fire1") && isStarted == true && allowShoot == true)
            {
                Shoot();
            }
        }

        if (panel.activeInHierarchy)
        {
            allowShoot = false;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        SoundManagerDoodle.PlaySound("shoot");
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    //public void StopShoot()
    //{
    //    isStarted = false;
    //}
}
