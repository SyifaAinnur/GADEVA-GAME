using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogManagerIdle : MonoBehaviour
{
    [SerializeField] GameObject dialogIdleBox;
    [SerializeField] Text dialogIdleText;
    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialogIdle;
    public event Action OnCloseDialogIdle;


    public static DialogManagerIdle Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    DialogIdle dialogidle;
    Action onDialogFinished;
    int currentLine = 0;
    bool isTyping;
    public IEnumerator ShowDialogIdle(DialogIdle dialogidle, Action onFinished = null)
    {
        yield return new WaitForEndOfFrame();

        OnShowDialogIdle?.Invoke();
        this.dialogidle = dialogidle;
        dialogIdleBox.SetActive(true);
        StartCoroutine(TypeDialog(dialogidle.Lines[0]));
    }
    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isTyping)
        {
            ++currentLine;
            if (currentLine < dialogidle.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialogidle.Lines[currentLine]));
            }
            else
            {
                currentLine = 0;
                dialogIdleBox.SetActive(false);
                OnCloseDialogIdle.Invoke();
            }
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogIdleText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogIdleText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }
}
