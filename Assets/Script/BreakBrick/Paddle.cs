using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Paddle : MonoBehaviour
{
    public float speed;
    public Transform rightScreenEdge;
    public Transform leftScreenEdge;
    public GameManager gm;

    [SerializeField] GameObject startPanel;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (startPanel.activeSelf == true)
        {
            return;
        }
        if (gm.gameover == true)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);
        if (transform.position.x < leftScreenEdge.position.x + 1)
        {
            transform.position = new Vector2(leftScreenEdge.position.x + 1, transform.position.y);
        }
        if (transform.position.x > rightScreenEdge.position.x - 1)
        {
            transform.position = new Vector2(rightScreenEdge.position.x - 1, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //ngecek
        // Debug.Log("kena " + other.name);
        if (other.CompareTag("special"))
        {
            gm.UpdateLives(1);
            Destroy(other.gameObject);
        }

    }
}
