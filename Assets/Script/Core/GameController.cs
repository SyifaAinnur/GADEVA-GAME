using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState
{
    FreeRoam, Dialog, DialogIdle, Paused
}

public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    [HideInInspector] public string namaScene;
    [SerializeField] Camera worldCamera;

    [HideInInspector] public GameObject NpcAchievment;


    [SerializeField] private Pause pausebtn;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Character player;

    [SerializeField] private CharacterAnimator playerAnimator;
    
    GameState state;
    GameState stateBeforePause;

    public SceneDetails CurrentScene { get; private set; }
    public SceneDetails PrevScene { get; private set; }

    public static GameController Instance { get; private set; }


    void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        playerController.gameObject.SetActive(true);

        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };

        DialogManager.Instance.OnCloseDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
        };

        DialogManagerIdle.Instance.OnShowDialogIdle += () =>
        {
            state = GameState.DialogIdle;
        };

        DialogManagerIdle.Instance.OnCloseDialogIdle += () =>
        {
            if (state == GameState.DialogIdle)
                state = GameState.FreeRoam;
        };


    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            stateBeforePause = state;
            state = GameState.Paused;

        }
        else
        {
            state = stateBeforePause;
        }
    }


    private void Update()
    {
        if (!playerAnimator.pause && !playerAnimator.IsMoving)
        {
            pauseMenu.gameObject.SetActive(true);
        }
        else
        {
            pauseMenu.gameObject.SetActive(false);
        }
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
        else if (state == GameState.DialogIdle)
        {
            DialogManagerIdle.Instance.HandleUpdate();
        }

    }

    public void Quit()
    {
        Time.timeScale = 1;
        playerAnimator.pause = false;
        pausebtn.gameObject.SetActive(false);
        playerController.gameObject.SetActive(false);
        namaScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("MainMenu");

        //cekl apakah work
        Debug.Log("game Keluar");
    }

    public void SetCureentScene(SceneDetails currScene)
    {
        PrevScene = CurrentScene;
        CurrentScene = currScene;
    }

}
