using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameScript : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject miniGame2;
    [SerializeField] private GameObject profile;
    [SerializeField] private Text chatText;
    [SerializeField] private Text[] achievement;

    private bool move = false;


    private void FixedUpdate()
    {
        if (move)
        {
            Transform cam = Camera.main.transform;
            Vector3 targetPosition = new Vector3(miniGame2.transform.position.x, miniGame2.transform.position.y, cam.position.z);
            cam.position = Vector3.Lerp(cam.position, targetPosition, 0.04f);

            if (cam.position == targetPosition) move = false;
        }
    }

    public void miniGame()
    {
        panel.SetActive(true);
        StartCoroutine(countDount());
    }

    private IEnumerator countDount()
    {
        GetComponent<Moving>().enabled = false;
        yield return new WaitForSeconds(6);
        panel.SetActive(false);
        
        chatText.transform.parent.gameObject.SetActive(false);
        chatText.transform.parent.gameObject.SetActive(true);
        chatText.text = "Keren, anda menyelesaikannya dengan baik!";

        profile.SetActive(true);

        achievement[0].color = Color.white;
        yield return new WaitForSeconds(2);
        achievement[0].color = Color.grey;
        yield return new WaitForSeconds(1);

        achievement[0].color = Color.white;
        yield return new WaitForSeconds(1);
        achievement[0].color = Color.grey;
        yield return new WaitForSeconds(1);

        achievement[0].color = Color.white;
        yield return new WaitForSeconds(1);
        achievement[0].color = Color.grey;
        yield return new WaitForSeconds(0.4f);

        achievement[0].color = Color.white;
        chatText.transform.parent.gameObject.SetActive(false);
        
        Transform cam = Camera.main.transform;
        Vector3 targetPosition = new Vector3(miniGame2.transform.position.x, miniGame2.transform.position.y, cam.position.z);

        move = true;

        new WaitUntil(() => !move);

        miniGame2.SetActive(true);

        yield return new WaitForSeconds(3);
        cam.position = new Vector3(transform.position.x, transform.position.y, cam.position.z);
        GetComponent<Moving>().enabled = true;
    }

}
