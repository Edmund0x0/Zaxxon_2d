using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score_board : MonoBehaviour
{
    public static score_board instanceScore;
    public int score = 0;

    private void Awake()
    {
        instanceScore = this;
    }

    public void addScoreEnemyKill()
    {
        score += 5;
        GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
    }
}
