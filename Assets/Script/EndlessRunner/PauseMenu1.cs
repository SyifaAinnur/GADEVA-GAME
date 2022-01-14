using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{

    [SerializeField] TurnOffEssentialObject turnOff;
    GameObject pauseMenu;

    public bool isPause = false;

    private void Start()
    {
        
        pauseMenu = gameObject;
        pauseMenu.SetActive(false);
      
    }

    public void Pause()
    {
        if(!pauseMenu) {
        Debug.LogError("gameobject menu diaktivkan saja"); 
        return;
        }
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("Wave 1");
        isPause = false;
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
