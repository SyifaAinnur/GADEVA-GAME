using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // GetComponent<AudioSource>().Play();
        // SceneManager.LoadScene("Intro1");
        StartCoroutine(Wait());

    }

    public void PlaySound()
    {
        
        GetComponent<AudioSource>().Play();

    }

    public void QuitGame()
    {
        StartCoroutine(Wait2());

    }

    private IEnumerator Wait()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.3f);
        GameController gc = FindObjectOfType<GameController>();
        if (gc != null)
        {
            Debug.Log("test" + gc.namaScene);
            gc.playerController.gameObject.SetActive(true);
            FindObjectOfType<SoundManager>().GetComponent<AudioSource>().Play();
            SceneManager.LoadScene(gc.namaScene);
        }
        else
        {
            SceneManager.LoadScene("Intro1");
        }
    }

    private IEnumerator Wait2()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.3f);

        Application.Quit();
    }
}
