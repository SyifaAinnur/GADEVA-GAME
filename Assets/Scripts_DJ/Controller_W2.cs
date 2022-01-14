using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_W2 : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10f;
    public GameObject player;
    public GameObject winPlat;

    private bool isStarted = false;

    public float maxScore;
    public float topScore = 0.0f;
    public int maxHealth = 20;
    public int currentHealth;

    public Text scoreText;
    public Text startText;
    public Text gameoverText;
    public GameObject losemenu;
    public Text winText;
    public GameObject panel;
    public GameObject textArea;

    public SpawnEnemy spawn;
    public ProgressBar progressbar;

    public BossController bossController;
    public DamageFlickerPlayer damageFlicker;
    public PlayerHealthBar playerHealthBar;
    DialogueTrigger dialogueTrigger;
    DialogueManager dialogueManager;

    [SerializeField] TurnOffEssentialObject turnOff;

    [SerializeField] GameObject startPanel;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthBar.SetMaxHealth(maxHealth);

        rb2d = GetComponent<Rigidbody2D>();
        progressbar = GameObject.FindObjectOfType<ProgressBar>();

        rb2d.gravityScale = 0;
        rb2d.velocity = Vector3.zero;

        scoreText.gameObject.SetActive(false);
        //gameoverText.gameObject.SetActive(false);
        losemenu.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
        winPlat.transform.position = new Vector3(0, maxScore, 0);
        isStarted = false;
        PauseMenu.isPause = false;
        
    }

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
                startText.gameObject.SetActive(false);
                losemenu.gameObject.SetActive(false);
                rb2d.gravityScale = 5f;
                SoundManagerDoodle.PlaySound("theme");
            }
            
        }

        if(currentHealth ==0)
        {
            GameOver();
        }
    }

    void FixedUpdate()
    {
        if (isStarted == true)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerTakeDamage(1);
            Destroy(collision.gameObject);
            damageFlicker = FindObjectOfType<DamageFlickerPlayer>();
            damageFlicker.TakeDamage();
        }

        if (collision.gameObject.name == "BodyBoss")
        {
            //HealthTextScript.healthAmount -= 3;
            PlayerTakeDamage(3);
            damageFlicker = FindObjectOfType<DamageFlickerPlayer>();
            damageFlicker.TakeDamage();
        }

        if (collision.gameObject.name == "HeadBoss")
        {
            SoundManagerDoodle.PlaySound("explode");
            bossController = FindObjectOfType<BossController>();
            bossController.TakeDamage(3);
        }

        if (collision.gameObject.tag == "Suriken")
        {
            //HealthTextScript.healthAmount -= 1;
            PlayerTakeDamage(3);
            damageFlicker = FindObjectOfType<DamageFlickerPlayer>();
            damageFlicker.TakeDamage();
        }

        if (collision.gameObject.tag == "winPlat")
        {
            Invoke("Win", 0.3f);
        }

        if(currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        //gameoverText.gameObject.SetActive(true);
        losemenu.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
        rb2d.gravityScale = 0;
        rb2d.velocity = Vector3.zero;
        //isStarted = false;
        this.enabled = false;
    }

    public void Win()
    {
        //winText.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
        rb2d.gravityScale = 0;
        rb2d.velocity = Vector3.zero;
        //isStarted = false;
        this.enabled = false;
        textArea.gameObject.SetActive(true);
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        dialogueTrigger.TriggerDialogue();
    }

    void PlayerTakeDamage(int damage)
    {
        currentHealth -= damage;
        playerHealthBar.SetHealth(currentHealth);
    }
}
