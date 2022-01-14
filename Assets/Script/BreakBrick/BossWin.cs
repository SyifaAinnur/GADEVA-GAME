using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BossWin : MonoBehaviour
{
    [SerializeField] private Text chatend;
    [SerializeField] private Text nama;
    private int spacecount = 0;

    private bool process = false;
    [SerializeField] private GameObject pauseObj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && process == true)
        {
            spacecount++;
        }
    }

    public IEnumerator winBossChat(GameObject player)
    {
        pauseObj.SetActive(false);
        process = true;
        nama.text = "TokoKaiju";
        chatend.transform.parent.parent.gameObject.SetActive(true);
        chatend.text = "Sial diluar dugaan, kau benar-benar bisa mengalahkanku,\n Ku akui kekalahan ku dan juga kehebatanmu bocah!";

        yield return new WaitUntil(() => spacecount == 1);

        chatend.text = "Kau bisa mengambil achievement sebagai tanda keberhasilanmu pada tantangan ini.";
        yield return new WaitUntil(() => spacecount == 2);

        chatend.text = "Bicaralah pada monster yang berada di pertigaan. dia akan memberikan hadiah untukmu.";
        yield return new WaitUntil(() => spacecount == 3);

        player.SetActive(true);
        player.GetComponent<TurnGameObject>().TurnOn();
        player.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 1;
        WinCondition.SetResult("Trainer1");
        SceneManager.LoadScene("GamePlay");

        yield return 0;
    }

}
