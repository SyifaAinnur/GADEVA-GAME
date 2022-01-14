using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueMid : MonoBehaviour
{
    [SerializeField] private Text nama;
    [SerializeField] private Text dialog;
    [SerializeField] private GameObject paneldialog;

    [SerializeField] private GameObject pauseObj;
    private int spacecount = 0;
    private bool process = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && process == true)
        {
            spacecount++;
        }
    }
    public IEnumerator Dialogue(GameObject player)
    {
        pauseObj.SetActive(false);
        paneldialog.SetActive(true);
        process = true;
        nama.text = "TokoKaiju";
        dialog.text = "Sial, kau terlalu kuat \n Ku akui kelayakanmu untuk menghadapiku. ";
        //yield return untuk memulai urutan/antrian(tidak tereksekusi bila tidak kena trigger)
        yield return new WaitUntil(() => spacecount == 1);
        dialog.text = "Ya sudah, LAWAN AKU SAJA!!!! ";
        yield return new WaitUntil(() => spacecount == 2);
        player.SetActive(true);
        player.transform.GetChild(0).gameObject.SetActive(true);
        SceneManager.LoadScene("Bossmatch");
    }


}
