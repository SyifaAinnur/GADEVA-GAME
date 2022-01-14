using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] TurnOffEssentialObject turnOff;
    public static bool isPause = false;


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void Restart()
    {
        turnOff.player.SetActive(true);
        isPause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("DoodleJump");
    }

    public void Quit()
    {
        turnOff.player.SetActive(true);
        isPause = false;
        turnOff.player.GetComponent<TurnGameObject>().TurnOn();
        turnOff.player.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }
}
