using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStart;
    public bool gameOver;
    private bool gameRunning;
    private bool gameStopped;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        gameStart = false;
        gameOver = false;
        gameRunning = false;
        gameStopped = false;
    }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameStart)
        {
            GameStart();
        }
        if (gameOver)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GameStart()
    {
        if (!gameRunning)
        {
            gameRunning = true;
            StatsManager.instance.StartScore();
            UIManager.instance.GameStart();
            GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
        }
    }

    public void GameOver()
    {
        if (!gameStopped)
        {
            gameStopped = true;
            StatsManager.instance.StopScore();
            UIManager.instance.GameOver();

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}