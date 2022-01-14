using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGameObject : MonoBehaviour
{
    public GameObject soundManager;


    public void TurnOn()
    {
        soundManager.SetActive(true);
    }

    public void TurnOff()
    {
        soundManager.SetActive(false);
    }


}
