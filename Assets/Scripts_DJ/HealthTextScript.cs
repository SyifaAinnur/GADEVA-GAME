using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextScript : MonoBehaviour
{
    [HideInInspector] public Text text;
    public static int healthAmount = 5;
    [SerializeField] Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        healthAmount = 5;
    }

    // Update is called once per frame

}
