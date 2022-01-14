using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    [SerializeField] string NamaScene;

    public void Move()
    {
        if (NamaScene == "")
        {
            Debug.LogError("Isi Nama Scene Di GameObject IntroManager Di Scene: "+SceneManager.GetActiveScene().name);
            return;
        }

        SceneManager.LoadScene(NamaScene);
    }
}
