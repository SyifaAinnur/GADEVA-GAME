using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class PortalEnding : MonoBehaviour
{
    [SerializeField] int sceneToLoad = -1;

    PlayerController player;
    private void OnTriggerEnter2D(Collider2D other) {
        
        Debug.Log("PortalEnding");
        player = other.GetComponent<PlayerController>();
        if (player == null) {
            return;
        }
        StartCoroutine(SwitchScene());
    }

    Fader fader;
    private void Start() 
    {
        fader = FindObjectOfType<Fader>();  
    }

    IEnumerator SwitchScene()
    {

        GameController.Instance.PauseGame(true);
        yield return fader.FadeIn(0.5f);
        Destroy(player.transform.parent.gameObject);
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
    }


}
