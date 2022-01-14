using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] GameObject losePanel;

    //public static bool isPause = false;

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("DoodleJump");

    }

    public void Quit(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
        //isPause = false;
    }
}
