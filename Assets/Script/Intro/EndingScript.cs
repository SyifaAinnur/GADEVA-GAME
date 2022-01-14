using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    [SerializeField] private GameObject Gadeva;

    [SerializeField] private GameObject blackPanel;
    [SerializeField] private Text Chat;
    [SerializeField] private Text Name;
    [SerializeField] private GameObject credit;
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject TheEnd;

    private int sps = 0;
    private bool process = false;


    private void Start()
    {
        Name.text = "";
        Chat.text = "";
        StartCoroutine(countDount());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !process) sps++;
    }

    private IEnumerator countDount()
    {
        yield return new WaitForSeconds(1f);
        Chat.transform.parent.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        sps = 0;
        Name.text = "Suara Langit";
        StartCoroutine(ChatText("Gadeva Putra!\nKau telah melewati banyak hal didunia ini."));
        yield return new WaitUntil(() => sps == 1);
        StartCoroutine(ChatText("Kau telah menyelesaikan semua tantangan\ndan membuktikan kehebetan mu!"));
        yield return new WaitUntil(() => sps == 2);
        StartCoroutine(ChatText("Dengan begini kau dapat kembali ke duniamu\ndan menggapai mimpimu untuk menjadi seorang game developer!"));
        yield return new WaitUntil(() => sps == 3);
        StartCoroutine(ChatText("Portal ini akan membawamu kembali ke dunia asal mu!"));
        yield return new WaitUntil(() => sps == 4);
        Name.text = "Gadeva";
        StartCoroutine(ChatText("Yah...\nHaha benar-benar pengalaman yang hebat!"));
        yield return new WaitUntil(() => sps == 5);
        StartCoroutine(ChatText("Baiklah!\nAku akan kembali keduniaku dan menjadi seorang game developer!"));
        yield return new WaitUntil(() => sps == 6);
        StartCoroutine(ChatText("Selamat tinggal..."));
        yield return new WaitUntil(() => sps == 7);
        Chat.transform.parent.gameObject.SetActive(false);
        Name.text = "";
        Chat.text = "";
        GetComponent<Animator>().SetBool("Go", true);
        yield return new WaitForSeconds(2f);

        blackPanel.SetActive(true);
        Chat.transform.parent.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        sps = 0;
        Name.text = "Gadeva";
        StartCoroutine(ChatText("Benar!"));
        yield return new WaitUntil(() => sps == 1);
        StartCoroutine(ChatText("Aku telah melewati banyak hal disini..."));
        yield return new WaitUntil(() => sps == 2);
        StartCoroutine(ChatText("Aku siap untuk kembali keduniaku dan mengejar mimpiku untuk menjadi..."));
        yield return new WaitUntil(() => sps == 3);
        StartCoroutine(ChatText("GAME DEVELOPER!"));
        yield return new WaitUntil(() => sps == 4);
        Chat.transform.parent.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        Gadeva.SetActive(true);
        yield return new WaitForSeconds(3f);
        Gadeva.SetActive(false);
        credit.SetActive(true);
        yield return new WaitForSeconds(18f);
        credit.SetActive(false);
        logo.SetActive(true);
        yield return new WaitForSeconds(3f);
        logo.SetActive(false);
        TheEnd.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator ChatText(string chatString)
    {
        process = true;
        Chat.text = "";
        char[] arrayChat = chatString.ToCharArray();
        foreach (char item in arrayChat)
        {
            Chat.text += item;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.1f);
        process = false;
    }
}