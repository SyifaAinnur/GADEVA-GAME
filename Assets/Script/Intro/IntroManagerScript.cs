using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManagerScript : MonoBehaviour
{
    [SerializeField] Text dialog;
    [SerializeField] Text name;
    [SerializeField] Animator charAnim;
    [SerializeField] Animator JendelaAnim;
    [SerializeField] Animator SleepAnim;
    [SerializeField] GameObject TvFx;
    [SerializeField] GameObject Transition;

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

    public void PlayTrans()
    {
        Transition.SetActive(false);
        Transition.SetActive(true);
    }

    private IEnumerator countDount()
    {
        yield return new WaitForSeconds(1f);
        sps = 0;
        name.text = "TV";
        StartCoroutine(ChatText("GAME DEVELOPER. Anda suka bermain game ?\nHei! bagaimana jika anda mencoba membuatnya! "));
        yield return new WaitUntil(() => sps == 1);
        StartCoroutine(ChatText("GAME DEVELOPER. Industri game sedang memuncak,\nKeuntungan yang diraih luar biasa besar!\nJika anda tertarik, begabunglah bersama kami menjadi GAME DEVELOPER!"));
        yield return new WaitUntil(() => sps == 2);
        TvFx.SetActive(false);
        name.text = "Gadeva";
        StartCoroutine(ChatText("Ahhhhh... menjadi game developer.\nAku benar-benar ingin sekali menjadi bagian dari mereka\ndan membuat game bersama-sama."));
        yield return new WaitUntil(() => sps == 3);
        StartCoroutine(ChatText("YOSHH!!! Dengan semua kerja keras yang telah kulakukan selama ini. Belajar bahasa program, Mengikuti bootcamp,\ndan juga melihat berbagai dokumentasi di YoTube."));
        yield return new WaitUntil(() => sps == 4);
        StartCoroutine(ChatText("AKU AKAN MENJADI GAME DEVELOPER!"));
        yield return new WaitUntil(() => sps == 5);
        StartCoroutine(ChatText(""));
        JendelaAnim.SetBool("Intro1",true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(ChatText("?!"));
        charAnim.SetBool("Intro1",true);
        yield return new WaitForSeconds(2.4f);
        sps = 0;
        yield return new WaitUntil(() => sps == 1);
        StartCoroutine(ChatText("..."));
        yield return new WaitUntil(() => sps == 2);
        StartCoroutine(ChatText("Langit begitu cerah malam ini...\nTerlihat begitu indah."));
        yield return new WaitUntil(() => sps == 3);
        StartCoroutine(ChatText("Langit apa kau mendengarku ?"));
        yield return new WaitUntil(() => sps == 4);
        StartCoroutine(ChatText("Aku ingin sekali menjadi game developer."));
        yield return new WaitUntil(() => sps == 5);
        StartCoroutine(ChatText("..."));
        yield return new WaitUntil(() => sps == 6);
        StartCoroutine(ChatText("Hoaaaammm..."));
        yield return new WaitUntil(() => sps == 7);
        StartCoroutine(ChatText("..."));
        yield return new WaitUntil(() => sps == 8);
        StartCoroutine(ChatText("Sudah waktunya untuk tidur..."));
        yield return new WaitUntil(() => sps == 9);
        dialog.transform.parent.gameObject.SetActive(false);
        SleepAnim.SetBool("Close",true);
        yield return new WaitForSeconds(2f);
        SleepAnim.SetBool("Close", false);
        yield return new WaitForSeconds(2f);
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
