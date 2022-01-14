using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] PauseMenu1 pauseMenu;
    [SerializeField] Sprite[] Player;

    

    [SerializeField] GameObject StartPanel;

    public GameObject bulletPrefab;

    public float bulletForce = 80f;

    // private bool isStarted = false;

    // public GameObject panel;


    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space) && isStarted == false)
        // {
        //     isStarted = true;
        // }


        if (Input.GetButtonDown("Fire1") && !pauseMenu.isPause && !StartPanel.activeSelf)
        {
            Shoot();
        }


        // if(panel.activeInHierarchy)
        // {
        //     isStarted = false;
        // }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.GetChild(1).position, Quaternion.identity);
        StartCoroutine(GantiHati());
        bullet.GetComponent<Bullet>().player = transform;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // SoundManager.PlaySound("shoot");
        rb.AddForce(Vector3.right * bulletForce, ForceMode2D.Impulse);
    }

    private IEnumerator GantiHati()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Player[1];
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Player[0];
    }

    // public void StopShoot()
    // {
    //     isStarted = false;
    // }
}
