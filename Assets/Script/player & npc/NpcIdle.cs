using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcIdle : MonoBehaviour, Interactable
{
    [SerializeField] DialogIdle dialogidle;

    NPCState state;
    float idleTimer = 0f;
    Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    public void Interact(Transform initiator)
    {
        if (state == NPCState.Idle)
        {
            state = NPCState.Dialog;
            character.LookTowards(initiator.position);

            StartCoroutine(DialogManagerIdle.Instance.ShowDialogIdle(dialogidle, () =>
            {
                idleTimer = 0f;
                state = NPCState.Idle;
            }));
        }

    }
}
