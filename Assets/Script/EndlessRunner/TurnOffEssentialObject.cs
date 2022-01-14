using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnOffEssentialObject : MonoBehaviour
{

    [HideInInspector] public GameObject player;
    
    // Start is called before the first frame updat
    void Start() {
    if (SceneManager.GetActiveScene().name == "Doodle Jump Wave 2")
    {
        player = Transisi.GetPlayer();

    }
    
        player = FindObjectOfType<PlayerController>().gameObject;
        player.GetComponent<TurnGameObject>().TurnOff();
        Transisi.SetPlayer(player);
        player.SetActive(false);
        //Debug.Log(player.name);
    
    }

    // Update is called once per frame
}
