using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerEndless : MonoBehaviour
{

    private bool boss;
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    private int HealtPoint = 5;
    // [SerializeField] GameObject winPannel;
    [SerializeField] DialogueMidEndless Dialogue;
    [SerializeField] GameObject pauseButton;
    [SerializeField] Text HealtPointText;

    [SerializeField] Transform[] BatasPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().name == "Wave 1")
        {
            boss = false;

        }
        else
        {
            boss = true;
        }
        HealtPointText.text = "x" + HealtPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (!boss)
        {
            Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            playerDirection = direction.normalized;
        }
        else
        {
            Vector2 direction = new Vector2(0, Input.GetAxisRaw("Vertical"));
            playerDirection = direction.normalized;
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);

        if (!boss)
        {
            if (transform.position.x > BatasPlayer[1].position.x)
            {
                transform.position = new Vector2(BatasPlayer[1].position.x, transform.position.y);
            }
            else if (transform.position.x < BatasPlayer[0].position.x)
            {
                transform.position = new Vector2(BatasPlayer[0].position.x, transform.position.y);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Side Borders (1)")
        {
            Time.timeScale = 0f;
            pauseButton.SetActive(false);
            Dialogue.StartCoroutine(Dialogue.Dialogue());
        }
    }

    public IEnumerator KenaTembak()
    {

        HealtPoint -= 1;
        HealtPointText.text = "x" + HealtPoint;
        if (HealtPoint <= 0)
        {
            Destroy(gameObject);
        }
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
    }


}
