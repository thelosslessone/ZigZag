using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject zigZagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text bestScoreGameStart;
    public Text bestScoreGameOver;
    public Text inGameScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        bestScoreGameStart.text = "Best Score: " + StatsManager.instance.bestScore;
    }

    void Update()
    {
        inGameScore.text = StatsManager.instance.score.ToString();
    }
    public void GameStart()
    {
        tapText.GetComponent<Animator>().Play("textDown");
        //tapText.SetActive(false);
        zigZagPanel.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        score.text = StatsManager.instance.score.ToString();
        bestScoreGameOver.text = StatsManager.instance.bestScore.ToString();

        gameOverPanel.SetActive(true);
    }
}