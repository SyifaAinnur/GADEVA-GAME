using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10f;
    public GameObject player;
    public GameObject winPlat;

    private bool isStarted = false;

    public float maxScore;
    public float topScore = 0.0f;

    public Text scoreText;
    public Text startText;
    public Text gameoverText;
    public GameObject losemenu;
    public Text winText;
    public GameObject panel;
    public GameObject textArea;

    public SpawnEnemy spawn;
    public ProgressBar progressbar;
    DialogueTrigger dialogueTrigger;
    DialogueManager dialogueManager;

    [SerializeField] TurnOffEssentialObject turnOff;
    [SerializeField] GameObject startPanel;

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        progressbar = GameObject.FindObjectOfType<ProgressBar>();

        rb2d.gravityScale = 0;
        rb2d.velocity = Vector3.zero;

        scoreText.gameObject.SetActive(false);
        textArea.gameObject.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.Space) && isStarted == false && !startPanel.activeSelf)
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

        if (isStarted == true)
        {

            //if (moveInput < 0)
            //{
            //    this.GetComponent<SpriteRenderer>().flipX = true;
            //}
            //else
            //{
            //    this.GetComponent<SpriteRenderer>().flipX = false;
            //}

            if (rb2d.velocity.y > 0 && transform.position.y > topScore)
            {
                //tambahScore();

                topScore = transform.position.y;
                tambahProgress();

                if (topScore >= (maxScore - 10))
                {
                    winPlat.gameObject.SetActive(true);
                }

                //spawnPointX = transform.position.x;
                //spawnPointY = transform.position.y;
            }

            if (transform.position.y + 20 < topScore)
            {
                GameOver();
            }

            scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
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
        if (collision.gameObject.tag == "winPlat")
        {
            Win();
            //Invoke("Win", 0.3f);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name == "CollisionEnemy")
    //    {
    //        if (other.gameObject.tag == "Enemy")
    //        {
    //            GameOver();
    //            isStarted = false;
    //        }
    //    }
    //}

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
        //dialogueManager = FindObjectOfType<DialogueManager>();
        //dialogueManager.DisplayNextSentence();
        //if (dialogueManager.sentences.Count == 0)
        //{
        //    SceneManager.LoadScene("Doodle Jump Wave 2");
        //}
    }

    //public void tambahScore() 
    //{
    //    topScore = transform.position.y;
    //}

    public void tambahProgress()
    {
        progressbar.TambahProg(topScore);
        progressbar.MaxProgress(maxScore);
    }
}
