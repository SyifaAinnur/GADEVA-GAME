using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private Inventory inventory;

    [SerializeField] Character player;

    [SerializeField] CharacterAnimator playerAnimator;




    public void StartPauseAdv()
    {
        playerAnimator.pause = true;
        player.IsMoving = false;
        playerAnimator.IsMoving = false;
        inventory.LoadItem();
        menuUI.SetActive(true);
        Time.timeScale = 0;
        // StartCoroutine(WaitPause());
    }
    // private IEnumerator WaitPause()
    // {
    //     Debug.Log("WaitPause");
    //     yield return new WaitForSecondsRealtime(2f);
    //     ready = true;
    //     Time.timeScale = 0;

    // }

    public void StartPause()
    {

        menuUI.SetActive(true);
        Time.timeScale = 0;
        //Debug.Log("pause");

    }
    public void Resume()
    {
        Debug.Log("resume" + player.IsMoving);
        menuUI.SetActive(false);
        Time.timeScale = 1;
        
        playerAnimator.IsMoving = false;
        
        playerAnimator.pause = false;
        
    }
}
