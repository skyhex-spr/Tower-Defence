using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    public TextMeshProUGUI ScoreTXT;

    public void InititScore()
    {
        UpdateUI();
    }

    public void AddScore(int score)
    {
        Score += score;
        UpdateUI();
    }

    public void ReduceScore(int score)
    {
        Score -= score;
        if (Score <= 0) Score = 0;
        UpdateUI();
    }

    public void UpdateUI()
    {
        ScoreTXT.text = Score.ToString();
    }
}
