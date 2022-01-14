using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private bool PosX;
    [SerializeField] private bool PosY;

    private Text scoreText;
    private float currentScore;


    private void Start()
    {
        scoreText = transform.GetChild(1).GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        ShowScore();
    }

    private void ShowScore()
    {
        if (PosX && !PosY)
        {
            float currentX = player.transform.position.x;
            currentScore = currentX > currentScore ? currentX : currentScore;

            scoreText.text = currentScore.ToString("0.00");
        }
        else if (!PosX && PosY)
        {
            float currentY = player.transform.position.y;
            currentScore = currentY > currentScore ? currentY : currentScore;

            scoreText.text = currentScore.ToString("0.00");
        }
        else scoreText.text = "Error";
    }
}
