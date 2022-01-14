using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] GameObject pauseButton;
  
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            pauseButton.SetActive(false);
            gameOverPanel.SetActive(true);

        }
        
    }

  
}
