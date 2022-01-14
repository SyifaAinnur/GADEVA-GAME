using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject player;
    public Transform[] spawnPoints;
    public GameObject enemy;
    public GameObject enemyKiri;
    public GameObject Mini_enemy;
    public GameObject Mini_enemyKiri;
    int randomSpawnPoint, randomEnemy;
    public static bool spawnAllowed;
    public GameObject gameoverText;
    public GameObject losemenu;
    public GameObject panel;
    private GameObject instantiatedObj;
    private bool isStarted = false;

    public MonsterController monscon;

    [SerializeField] GameObject startPanel;

    private void Start()
    {
        spawnAllowed = false;
        isStarted = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isStarted == false && startPanel.activeSelf == false)
        {
            if (PauseMenu.isPause == true)
            {
                isStarted = false;
            }
            if (PauseMenu.isPause == false)
            {
                isStarted = true;
                Invoke("Allow", 5f);
                InvokeRepeating("SpawnAnEnemy", 0f, 5f);
            }
        }
        if (losemenu.activeInHierarchy)
        {
            DestroyWithTag("Enemy");
        }
        if (panel.activeInHierarchy)
        {
            DestroyWithTag("Enemy");
        }
    }

    void Allow()
    {
        spawnAllowed = true;
    }

    void SpawnAnEnemy()
    {
        if (spawnAllowed == true )
        {
            //enemy.GetComponent<SpriteRenderer>().flipX = false;
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "DoodleJump")
            {
                var spawnPosition = spawnPoints[1].position;

                instantiatedObj = (GameObject)Instantiate(enemyKiri, spawnPosition, Quaternion.identity);
                SoundManagerDoodle.PlaySound("enemy");

                spawnPosition = spawnPoints[0].position;

                instantiatedObj = (GameObject)Instantiate(enemy, spawnPosition, Quaternion.identity);
                SoundManagerDoodle.PlaySound("enemy");
            }

            if (sceneName == "Doodle Jump Wave 2")
            {
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                var spawnPosition = spawnPoints[randomSpawnPoint].position;
                if (spawnPosition.x < 0)
                {
                    instantiatedObj = (GameObject)Instantiate(Mini_enemyKiri, spawnPosition, Quaternion.identity);
                    SoundManagerDoodle.PlaySound("enemy");
                }

                else
                {
                    instantiatedObj = (GameObject)Instantiate(Mini_enemy, spawnPosition, Quaternion.identity);
                    SoundManagerDoodle.PlaySound("enemy");
                }
            }

            //if (spawnPosition.x < 0)
            //{
            //    instantiatedObj = (GameObject)Instantiate(enemyKiri, spawnPosition, Quaternion.identity);
            //    SoundManager.PlaySound("enemy");
            //}
            //else if (spawnPosition.x > 0)
            //{
            //    instantiatedObj = (GameObject)Instantiate(enemy, spawnPosition, Quaternion.identity);
            //}
            //else
            //{
            //    instantiatedObj = (GameObject)Instantiate(enemy, spawnPosition, Quaternion.identity);
            //    SoundManager.PlaySound("enemy");
            //}
            //if (spawnPoints.Length ==1)
            //{
            //    instantiatedObj = (GameObject)Instantiate(enemyKiri, spawnPosition, Quaternion.identity);
            //    if (spawnPosition.x < 0)
            //    {
            //        enemy.GetComponent<SpriteRenderer>().flipX = true;
            //    }
            //}
            //else if (spawnPoints.Length ==2)
            //{
            //    instantiatedObj = (GameObject)Instantiate(enemy, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
            //}


        }
        //if (gameoverText.activeInHierarchy)
        //{
        //    spawnAllowed = false;
        //}
        //if (winText.activeInHierarchy)
        //{
        //    spawnAllowed = false;
        //}
    }

    void DestroyWithTag(string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);
    }

}
