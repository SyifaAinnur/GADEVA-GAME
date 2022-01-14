using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainerController2 : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;

    Character character;

    public void Interact(Transform initiator)
    {
        character.LookTowards(initiator.position);

        StartCoroutine(DialogManager.Instance.ShowDialog(dialog, () =>
        {
            StopMusic();
            SceneManager.LoadScene("DoodleJump");
        }));
    }

    private void StopMusic()
    {
        FindObjectOfType<TurnGameObject>().TurnOff();
    }

    private void Awake()
    {
        Debug.Log("Awake");
        character = GetComponent<Character>();
    }


}
