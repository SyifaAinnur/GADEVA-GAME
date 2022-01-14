using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    [SerializeField] private Sprite Character1;
    [SerializeField] private Sprite[] AllFace;
    [SerializeField] private Sprite Window1;

    [SerializeField] private GameObject TV;
    [SerializeField] private GameObject Character;
    [SerializeField] private GameObject Face;
    [SerializeField] private GameObject Light;
    [SerializeField] private GameObject Window;
    [SerializeField] private GameObject Jam;
    [SerializeField] private GameObject Peri;
    [SerializeField] private GameObject Trans;

    [SerializeField] private Text Chat;

    private int sps = 0;
    private bool process = false;

    private void Start()
    {
        PlayTransition();
        StartCoroutine(countDount());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !process) sps++;
    }

    private void PlayTransition()
    {
        Trans.SetActive(false);
        Trans.SetActive(true);
    }

    private IEnumerator countDount()
    {
        TV.SetActive(true);
        StartCoroutine(ChatText(TV.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>(), "GAME DEVELOPER. Anda suka bermain game ?\nHei! bagaimana jika anda mencoba membuatnya! "));
        yield return new WaitUntil(() => sps == 1);
        StartCoroutine(ChatText(TV.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>(), "GAME DEVELOPER. Industri game sedang memuncak, Keuntungan yang diraih luar biasa besar!\nJika anda tertarik, begabunglah bersama kami menjadi GAME DEVELOPER!"));
        yield return new WaitUntil(() => sps == 2);
        PlayTransition();
        TV.SetActive(false);
        Character.SetActive(true);
        Chat.transform.parent.parent.gameObject.SetActive(true);
        StartCoroutine(ChatText(Chat, "Ahhhhh... menjadi game developer. \nAku benar-benar ingin sekali menjadi bagian dari mereka dan membuat game bersama-sama."));
        yield return new WaitUntil(() => sps == 3);
        Character.GetComponent<Image>().sprite = Character1;
        StartCoroutine(ChatText(Chat, "YOSHH!!! Dengan semua kerja keras yang telah kulakukan selama ini.\nBelajar bahasa program, Mengikuti bootcamp dan juga melihat berbagai dokumentasi di YoTube."));
        yield return new WaitUntil(() => sps == 4);
        StartCoroutine(ChatText(Chat, "AKU AKAN MENJADI GAME DEVELOPER!"));
        yield return new WaitUntil(() => sps == 5);
        Light.SetActive(true);
        yield return new WaitForSeconds(2f);
        Character.SetActive(false);
        Face.SetActive(true);
        StartCoroutine(ChatText(Chat, "...?!"));
        yield return new WaitForSeconds(2f);
        sps = 0;
        PlayTransition();
        Face.SetActive(false);
        Light.SetActive(false);
        Window.SetActive(true);
        StartCoroutine(ChatText(Chat, "Langit begitu cerah malam ini...\nTerlihat begitu indah."));
        yield return new WaitUntil(() => sps == 1);
        PlayTransition();
        Window.GetComponent<Image>().sprite = Window1;
        Face.GetComponent<Image>().sprite = AllFace[0];
        Face.SetActive(true);
        StartCoroutine(ChatText(Chat, "Langit apa kau mendengarku ?"));
        yield return new WaitUntil(() => sps == 2);
        Face.transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(ChatText(Chat, "Aku ingin sekali menjadi game developer."));
        yield return new WaitUntil(() => sps == 3);
        PlayTransition();
        Window.SetActive(false);
        Face.SetActive(false);
        Face.transform.GetChild(0).gameObject.SetActive(false);
        Jam.SetActive(true);
        StartCoroutine(ChatText(Chat, "Sudah waktunya untuk tidur..."));
        yield return new WaitUntil(() => sps == 4);
        Jam.SetActive(false);
        Chat.transform.parent.parent.gameObject.SetActive(false);
        Trans.transform.GetChild(0).gameObject.SetActive(true);
        PlayTransition();
        yield return new WaitForSeconds(2f);
        Trans.transform.GetChild(0).gameObject.SetActive(false);
        Face.GetComponent<Image>().sprite = AllFace[1];
        Face.SetActive(true);
        Chat.transform.parent.parent.gameObject.SetActive(true);
        StartCoroutine(ChatText(Chat, "Aa... Apa ini ?\nAku bermimpi aneh ? "));
        yield return new WaitUntil(() => sps == 5);
        Chat.transform.parent.parent.gameObject.SetActive(false);
        Face.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        Face.transform.GetChild(1).gameObject.SetActive(false);
        Face.GetComponent<Image>().sprite = AllFace[2];
        yield return new WaitForSeconds(0.6f);
        sps = 0;
        Face.GetComponent<Image>().sprite = AllFace[3];
        Chat.transform.parent.parent.gameObject.SetActive(true);
        StartCoroutine(ChatText(Chat, "Sakit..."));
        yield return new WaitUntil(() => sps == 1);
        Face.GetComponent<Image>().sprite = AllFace[1];
        StartCoroutine(ChatText(Chat, "Jadi aku tidak sedang bermimpi...\nTapi apa - apaan ini, Dimana aku ? "));
        yield return new WaitUntil(() => sps == 2);
        Face.SetActive(false);
        Peri.SetActive(true);
        StartCoroutine(ChatText(Chat, "Kau terjebak di dunia ini."));
        yield return new WaitUntil(() => sps == 3);
        Face.SetActive(true);
        Peri.SetActive(false);
        Face.GetComponent<Image>().sprite = AllFace[4];
        StartCoroutine(ChatText(Chat, "Apa maksudmu ?\nSiapa kau ? "));
        yield return new WaitUntil(() => sps == 4);
        Face.SetActive(false);
        Peri.SetActive(true);
        StartCoroutine(ChatText(Chat, "Aku adalah peri yang akan menemani mu."));
        yield return new WaitUntil(() => sps == 5);
        StartCoroutine(ChatText(Chat, "Di dunia ini kau akan di uji, apakah permohonan mu pantas untuk dikabulkan."));
        yield return new WaitUntil(() => sps == 6);
        StartCoroutine(ChatText(Chat, "Kau harus mendapatkan semua achievement yang ada.\nDengan begitu kau dapat keluar dari dunia ini."));
        yield return new WaitUntil(() => sps == 7);
        StartCoroutine(ChatText(Chat, "Apa itu sudah menjeleskan semuanya?"));
        yield return new WaitUntil(() => sps == 8);
        Face.SetActive(true);
        Face.GetComponent<Image>().sprite = AllFace[5];
        StartCoroutine(ChatText(Chat, "Cukup Jelas."));
        yield return new WaitUntil(() => sps == 9);
        StartCoroutine(ChatText(Chat, "Peri...\nTetaplah berada disisiku."));
    }


    private IEnumerator ChatText(Text area, string chatString)
    {
        process = true;
        area.text = "";
        char[] arrayChat = chatString.ToCharArray();
        foreach (char item in arrayChat)
        {
            area.text += item;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.1f);
        process = false;
    }
}
