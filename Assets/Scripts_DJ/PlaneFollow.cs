using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector2 planePosition;

    private float speedModifier;

    private bool coroutineAllowed;

    LevelLoader levelLoader;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.5f;
        coroutineAllowed = true;

        
        SoundManagerDoodle.PlaySound("plane");
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
        {
            
            StartCoroutine(GoByTheRoute(routeToGo));
        }
        


        //if (transform.position.x == -0.05749062 && transform.position.y == -4.576495)
        //{
        //    childGameObject.transform.SetParent(parrentGameObject);
        //}


    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            planePosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            transform.position = planePosition;

            
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;

        routeToGo += 1;

        if(routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
            //this.enabled = false;
        }

        coroutineAllowed = true;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Jadi");
            //Set the parent of that object to the platform
            collision.transform.parent = GameObject.Find("Plane").transform;

        }

        if (collision.gameObject.name == "DeteksiLevelLoader")
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "Transisi DoodleJump")
            {
                levelLoader = FindObjectOfType<LevelLoader>();
                levelLoader.LoadNextLevel();
            }

            if (sceneName == "Transisi DoodleJump2")
            {
                Debug.Log("Jadi2");
                player.transform.parent = null;
                Debug.Log("transisi");
                player.transform.position = new Vector3(0f, -5.603f, 0f);
                this.enabled = false;
                SceneManager.LoadScene("Doodle Jump Wave 2");

            }
        }

        //Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;
        //if (sceneName == "Transisi DoodleJump")
        //{
        //    if (collision.gameObject.name == "DeteksiLevelLoader")
        //    {
        //        levelLoader = FindObjectOfType<LevelLoader>();
        //        levelLoader.LoadNextLevel();
        //    }
        //}

        //if (sceneName == "Transisi DoodleJump2")
        //{
        //    if (collision.gameObject.name == "DeteksiLevelLoader")
        //    {
        //        Debug.Log("Jadi2");
        //        //Set the parent of that object to the platform
        //        //collision.transform.parent = GameObject.Find("Plane").transform;

        //    }
        //}

        //if (collision.gameObject.name == "DeteksiLevelLoader")
        //{
        //    levelLoader = FindObjectOfType<LevelLoader>();
        //    levelLoader.LoadNextLevel();
        //}

    }
}
