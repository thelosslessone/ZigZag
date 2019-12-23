using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager instance;


    public int score;
    public int bestScore;

    private void Awake()
    {
        //PlayerPrefs.SetInt("bestScore", 0);
        if (instance == null)
        {
            instance = this;
        }

    }

    private void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
        bestScore = PlayerPrefs.GetInt("bestScore");
    }



    void IncrementScore()
    {
        score++;
    }

    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.2f);
    }

    public void StopScore()
    {
        CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("bestScore"))
        {
            if (score > bestScore)
            {
                PlayerPrefs.SetInt("bestScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
    }
}