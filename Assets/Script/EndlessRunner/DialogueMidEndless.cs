using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueMidEndless : MonoBehaviour
{
    // [SerializeField] private Text nama;
    [SerializeField] private Text dialog;
    [SerializeField] private GameObject paneldialog;

    [SerializeField] private TurnOffEssentialObject turnOff;
    private int spacecount = 0;
    private bool process = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && process == true)
        {
            spacecount++;
        }
    }
    public IEnumerator Dialogue()
    {
        paneldialog.SetActive(true);
        process = true;
        // nama.text = "Boss";
        dialog.text = "Tidak perlu kau mengejarku ";
        //yield return untuk memulai urutan/antrian(tidak tereksekusi bila tidak kena trigger)
        yield return new WaitUntil (()=> spacecount == 1);
        dialog.text = "karena aku tau kemampuanmu ";
        yield return new WaitUntil (()=> spacecount == 2);
        dialog.text = "kau tidak akan bisa mengalahkanku!! ";
        yield return new WaitUntil(() => spacecount == 3);
        turnOff.player.SetActive(true);
        SceneManager.LoadScene("Wave 2");
    }


}
