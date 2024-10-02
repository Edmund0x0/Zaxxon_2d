using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score_board : MonoBehaviour
{
    public static score_board instanceScore { get; private set; }
    public int score { get; private set; } = 0;

    private void Awake()
    {
        instanceScore = this;
    }

    void Start()
    {
       // score = PlayerPrefs.GetInt("PlayerScore");
        UpdateScore();
    }

    public void addScoreEnemyKill(int add)
    {
        score += add;
      // PlayerPrefs.SetInt("PlayerScore", score);
        UpdateScore();
        
    }

    public void UpdateScore()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
    }
}
