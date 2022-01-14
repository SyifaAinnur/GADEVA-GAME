using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    
    private Vector3[] positions;
    private int index;
    private int current;
    private bool isWaiting = false;
    public bool isStarted = false;

    public GameObject losePanel;

    public int maxHealth = 100;
    public int currentHealth;


    public BossHealthBar healthBar;
    public Controller_W2 controller;
    public RotateSuriken rotateSuriken;
    public RotateChildSuriken rotateChildSuriken;
    public RotateChildSuriken rotateChildSuriken2;
    public RotateChildSuriken rotateChildSuriken3;
    public RotateChildSuriken rotateChildSuriken4;
    public RotateChildSuriken rotateChildSuriken5;
    public RotateChildSuriken rotateChildSuriken6;
    public RotateChildSuriken rotateChildSuriken7;
    public RotateChildSuriken rotateChildSuriken8;

    public GameObject jurusBoss;

    public SpriteRenderer sprite;

    public DamageFlicker damageFlicker;

    [SerializeField] GameObject startPanel;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Example());
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        jurusBoss.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isStarted == false && startPanel.activeSelf == false)
        {
            if (PauseMenu.isPause == true)
            {
                isStarted = false;
            }
            if (PauseMenu.isPause == false)
            {
                isStarted = true;
            }
            
            
        }
        Move();

        if (currentHealth <= 0)
        {
            controller = FindObjectOfType<Controller_W2>();
            controller.Win();
            Destroy(gameObject);
        }

        if(losePanel.activeInHierarchy)
        {
            this.enabled = false;
            Destroy(gameObject);
        }

    }

    public void Move()
    {
        if(!isWaiting && isStarted == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

            if (transform.position == positions[index])
            {
                if (index == positions.Length - 1)
                {
                    index = 0;
                }
                if (index == 4 || index ==5)
                {
                    StartCoroutine(Wait());
                    index++;
                }
                else
                {
                    index++;
                }
            }

            if(index == 6)
            {
                jurusBoss.gameObject.SetActive(true);
                rotateSuriken.GetComponent<RotateSuriken>().isRotate = true;
                rotateChildSuriken.GetComponent<RotateChildSuriken>().isRotate = true;
                rotateChildSuriken2.GetComponent<RotateChildSuriken>().isRotate = true;
                rotateChildSuriken3.GetComponent<RotateChildSuriken>().isRotate = true;
                rotateChildSuriken4.GetComponent<RotateChildSuriken>().isRotate = true;
                rotateChildSuriken5.GetComponent<RotateChildSuriken>().isRotate = true;
                rotateChildSuriken6.GetComponent<RotateChildSuriken>().isRotate = true;
                rotateChildSuriken7.GetComponent<RotateChildSuriken>().isRotate = true;
                rotateChildSuriken8.GetComponent<RotateChildSuriken>().isRotate = true;
                StartCoroutine(StopSpawn());
            }

            
        }
        
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(2);
        isWaiting = false;
    }

    IEnumerator StopSpawn()
    {
        yield return new WaitForSeconds(7);
        jurusBoss.gameObject.SetActive(false);
        rotateSuriken.GetComponent<RotateSuriken>().isRotate = false;
        rotateChildSuriken.GetComponent<RotateChildSuriken>().isRotate = false;
        rotateChildSuriken2.GetComponent<RotateChildSuriken>().isRotate = false;
        rotateChildSuriken3.GetComponent<RotateChildSuriken>().isRotate = false;
        rotateChildSuriken4.GetComponent<RotateChildSuriken>().isRotate = false;
        rotateChildSuriken5.GetComponent<RotateChildSuriken>().isRotate = false;
        rotateChildSuriken6.GetComponent<RotateChildSuriken>().isRotate = false;
        rotateChildSuriken7.GetComponent<RotateChildSuriken>().isRotate = false;
        rotateChildSuriken8.GetComponent<RotateChildSuriken>().isRotate = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            //case "Bullet":
            //    //Instantiate(explosion, transform.position, Quaternion.identity);
            //    //KillsCounter.killsNumber += 1;
            //    SoundManager.PlaySound("explode");
            //    TakeDamage(1);
            //    break;

            case "Player":
            //    //TakeDamage(20);
                break;


            //case "KillBoss":
            //    TakeDamage(10);
            //    break;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        damageFlicker = FindObjectOfType<DamageFlicker>();
        damageFlicker.TakeDamage();
    }
    //IEnumerator Example()
    //{

    //}
}
