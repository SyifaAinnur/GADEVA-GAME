using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 0.8f;

    // Start is called before the first frame update
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        // transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "DoodleJump")
        {
            SceneManager.LoadScene("Transisi DoodleJump");
        }

        if (sceneName == "Transisi DoodleJump")
        {
            SceneManager.LoadScene("Transisi DoodleJump2");
        }

    }
}
