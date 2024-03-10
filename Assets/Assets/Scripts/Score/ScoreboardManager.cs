using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ScoreboardManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreboardText;

    private List<int> scores = new List<int>();

    void Start()
    {
        if (scoreText != null)
        {
            int currentScore = GameManager.Instance.Score;
            scores.Add(currentScore);

            int newScore = 1000;
            scores.Add(newScore);

            int firstScore = scores[0];

            SaveScores();

            scoreText.text = "Score: " + currentScore.ToString("D5");
            DisplayScoreboard();
        }
    }

    void SaveScores()
    {
      
        scores.Sort((a, b) => b.CompareTo(a));
       
        if (scores.Count > 3)
        {
            scores.RemoveRange(3, scores.Count - 3);
        }

        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetInt("Score" + (i + 1), scores[i]);
        }
    }

    void DisplayScoreboard()
    {
        scoreboardText.text = "Top 2 Scores:\n";

        for (int i = 0; i < scores.Count; i++)
        {
            scoreboardText.text += $"{i + 1}. {scores[i].ToString("D5")}\n";
        }
    }
}



