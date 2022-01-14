using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatAdventure : MonoBehaviour
{
    [SerializeField] private Text area;
    [SerializeField] private Image Ach1;
    [SerializeField] private GameObject achievement;
    private int num = 0;
    private bool process = true;


    private void Start()
    {
        StartCoroutine(countDount());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !process)
        {
            num++;

            Debug.Log(num);

        }
    }

    private IEnumerator countDount()
    {
        yield return new WaitForSeconds(16f);
        area.transform.parent.gameObject.SetActive(true);
        area.text = "";
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChatText("Kamu berhasil!"));
        yield return new WaitUntil(() => num == 1);
        StartCoroutine(ChatText("Kamu layak mendapatkan achievement ini"));
        yield return new WaitUntil(() => num == 2);
        area.transform.parent.gameObject.SetActive(false);
        Ach1.color = Color.white;
        achievement.SetActive(true);
        yield return new WaitForSeconds(3f);
        achievement.SetActive(false);
    }

    private IEnumerator ChatText(string chatString)
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
