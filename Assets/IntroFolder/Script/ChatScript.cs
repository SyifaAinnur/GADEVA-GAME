using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatScript : MonoBehaviour
{
    [SerializeField] private GameObject Action;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
            Action.SetActive(false);
            Action.SetActive(true);
        }
    }
}
