using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseCondition : MonoBehaviour
{
    [SerializeField] string Scene;

   public void ulangi()
   {
       SceneManager.LoadScene("Wave 1");
   }

    public void keluar()
   {
       SceneManager.LoadScene(Scene);
   }

}
