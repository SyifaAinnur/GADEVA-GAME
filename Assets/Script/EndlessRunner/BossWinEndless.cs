using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWinEndless : MonoBehaviour
{
//    [SerializeField] GameObject winPanel;
   [SerializeField] PauseMenu1 pauseMenu;
   [SerializeField] BOSSKATA Dialogue;
   [SerializeField] GameObject pauseButton;
   [SerializeField] TurnOffEssentialObject turnOff;

   public void winCondition()
   {
       Dialogue.StartCoroutine(Dialogue.winBossChat(turnOff.player));
   }
}
