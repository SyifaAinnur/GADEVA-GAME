using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Queue<string> sentences;

    LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        if (sentences.Count == 0)
        {

            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PauseMenu.isPause == true)
            {
                //
            }
            if (PauseMenu.isPause == false)
            {
                DisplayNextSentence();
            }

        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {

            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        //Debug.Log(sentence);
    }

    void EndDialogue()
    {
        //Debug.Log("End of conversation.");
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "DoodleJump")
        {
            //SceneManager.LoadScene("Transisi DoodleJump");
            levelLoader = FindObjectOfType<LevelLoader>();
            levelLoader.LoadNextLevel();
            Time.timeScale = 1;
        }
        if (sceneName == "Doodle Jump Wave 2")
        {
            Transisi.GetPlayer().SetActive(true);
            Transisi.GetPlayer().GetComponent<TurnGameObject>().TurnOn();
            // player.transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 1;
            Debug.Log("back to main game");
            WinCondition.SetResult("Trainer3");
            SceneManager.LoadScene("GamePlay");

        }
    }
}
