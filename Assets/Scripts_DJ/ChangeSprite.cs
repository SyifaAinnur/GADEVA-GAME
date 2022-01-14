using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite idleSprite, shootSprite;
    public GameObject mouth;
    public GameObject panel;
    public GameObject textArea;

    private bool isStarted = false;
    private bool allowChange = false;

    [SerializeField] GameObject startPanel;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        idleSprite = Resources.Load<Sprite>("player_DJ");
        shootSprite = Resources.Load<Sprite>("playerShoot_DJ");
        rend.sprite = idleSprite;
        mouth.gameObject.SetActive(false);
        //GameObject dialogueCanvas = GameObject.Find("Dialog Canvas");
        //GameObject textArea = dialogueCanvas.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isStarted == false && startPanel.activeSelf == false)
        {
            if (PauseMenu.isPause == true)
            {
                isStarted = false;
                allowChange = false;
            }
            if (PauseMenu.isPause == false)
            {
                isStarted = true;
                allowChange = true;
            }
                
        }

        if (PauseMenu.isPause == false)
        {
            if (Input.GetMouseButtonDown(0) && isStarted == true && allowChange == true)
            {
                rend.sprite = shootSprite;
                mouth.gameObject.SetActive(true);
            }
        }
            
        if (Input.GetMouseButtonUp(0) && isStarted == true && allowChange == true)
        {
            rend.sprite = idleSprite;
            mouth.gameObject.SetActive(false);
        }
        
        if (panel.activeInHierarchy)
        {
            allowChange = false;
        }

        if (textArea.activeInHierarchy)
        {
            rend.sprite = idleSprite;
            mouth.gameObject.SetActive(false);
        }
    }
}
