using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    // Start is called before the first frame update
    private int maxLifePoint = 100;
    private int lifePoint;
    [SerializeField] Slider Bar;
    [SerializeField] GameObject Virus;
    [SerializeField] Transform Player;
    [SerializeField] Text bossText;
    float dirX, moveSpeed = 8f;
    float timer = 5;
    bool moveRight = true;
    bool Tembakancinta = false;
    int index = 0;
    Vector3 TargetPosisi;
    bool FindTarget = false;

    private bool rage = false;


    private void Start()
    {
        lifePoint = maxLifePoint;
        Bar.maxValue = lifePoint;
        Bar.value = Bar.maxValue;
    }

    void Update()
    {
        if (timer < 0)
        {
            Tembakancinta = true;
            index = 0;
            TargetPosisi = new Vector3(transform.position.x, Player.position.y, transform.position.z);
            SpawnVirus();
            timer = Random.Range(5, 10);
        }
        else if (!Tembakancinta)
        {
            Movement();
            timer -= Time.deltaTime;
        }

        if (FindTarget)
        {
            if (Vector3.Distance(transform.position, TargetPosisi) > 1f)
            {
                transform.position = Vector3.Lerp(transform.position, TargetPosisi, 0.01f);
            }
            else
            {
                FindTarget = false;
            }

        }
    }

    public void kenaHatimu()
    {
        lifePoint--;
        Bar.value = lifePoint;
        StartCoroutine(gantiperasaan());
        if (lifePoint < maxLifePoint * 0.6f)
        {
            rage = true;
            bossText.text = "RUDRA";
        }
        if (lifePoint <= 0)
        {
            FindObjectOfType<BossWinEndless>().winCondition();
            Destroy(gameObject);
        }
    }

    private IEnumerator gantiperasaan()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void SpawnVirus()
    {


        if (rage)
        {
            Tembakancinta = false;
            transform.GetChild(0).GetComponent<Animator>().SetBool("rage", true);
        }
        else
        {
            FindTarget = true;
        }


        StartCoroutine(Recordcinta());


    }

    private IEnumerator Recordcinta()
    {
        if (index < 5)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(Virus, transform.position, Quaternion.identity);
            index++;
            StartCoroutine(Recordcinta());

        }
        else
        {
            Tembakancinta = false;
        }

    }

    private void Movement()
    {
        if (transform.position.y > 4f)
            moveRight = false;
        if (transform.position.y < -4f)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
    }

}
