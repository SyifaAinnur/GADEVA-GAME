using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro2ManagerScript : MonoBehaviour
{
    [SerializeField] Text dialog;
    [SerializeField] Text name;
    [SerializeField] Animator charAnim;
    [SerializeField] Animator SleepAnim;

    private bool process = true;
    private int sps = 0;


    private void Start()
    {
        StartCoroutine(countDount());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !process) sps++;
    }

    private IEnumerator countDount()
    {
        SleepAnim.SetBool("Open", true);
        yield return new WaitForSeconds(1.7f);
        SleepAnim.SetBool("Open", false);
        charAnim.SetBool("Intro2",true);
        name.text = "Gadeva";
        yield return new WaitForSeconds(1f);
        charAnim.SetBool("Intro3", true);
        dialog.transform.parent.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        sps = 0;
        StartCoroutine(ChatText("Aa... Apa ini ?\nApa-apaan ini, Dimana aku ?"));
        charAnim.SetBool("Intro3", true);
        yield return new WaitUntil(() => sps == 1);
        charAnim.SetBool("Intro4", true);
        StartCoroutine(ChatText("Ini... Seperti Dunia Game"));
        yield return new WaitUntil(() => sps == 2);
        StartCoroutine(ChatText("Aku bermimpi aneh ?"));
        yield return new WaitUntil(() => sps == 3);
        name.text = "Suara Langit";
        StartCoroutine(ChatText("Kau tidak sedang bermimpi"));
        yield return new WaitUntil(() => sps == 4);
        charAnim.SetBool("Intro5", true);
        name.text = "Gadeva";
        StartCoroutine(ChatText("Siapa ? dimana kau ?\nAp... apa maksudmu ?"));
        yield return new WaitUntil(() => sps == 5);
        name.text = "Suara Langit";
        StartCoroutine(ChatText("Didunia ini kau akan diuji, Apakah permohonanmu pantas untuk dikabulkan."));
        yield return new WaitUntil(() => sps == 6);
        StartCoroutine(ChatText("Untuk melakukannya,\nKau harus mendapatkan semua achievement yang ada.\nDengan begitu kau dapat keluar dari dunia ini."));
        yield return new WaitUntil(() => sps == 7);
        StartCoroutine(ChatText("Kau harus menunjukan bahwa kau layak!\nAku akan mengawasimu."));
        yield return new WaitUntil(() => sps == 8);
        name.text = "Gadeva";
        StartCoroutine(ChatText("Baik!"));
        yield return new WaitUntil(() => sps == 9);
        StartCoroutine(ChatText("Akanku tunjukan siapa aku!"));
        yield return new WaitUntil(() => sps == 10);
        try
        {
            FindObjectOfType<GameController>().playerController.gameObject.SetActive(true);
        }
        catch
        {

        }
        FindObjectOfType<PindahScene>().Move();
    }

    private IEnumerator ChatText(string chatString)
    {
        process = true;
        dialog.text = "";
        char[] arrayChat = chatString.ToCharArray();
        foreach (char item in arrayChat)
        {
            dialog.text += item;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.1f);
        process = false;
    }
}
