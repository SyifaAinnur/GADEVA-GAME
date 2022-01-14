using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] private GameObject textArea;
    [SerializeField] private GameObject Profile;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            textArea.SetActive(false);
            textArea.SetActive(true);

            Profile.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            textArea.SetActive(false);
        }
    }
}
