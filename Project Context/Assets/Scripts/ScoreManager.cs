using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int ScoreTeam1;
    public int ScoreTeam2;

    public Text ScoreTextTeam1;
    public Text ScoreTextTeam2;

    #region Singleton

    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private void Start()
    {
        ScoreTeam1 = 0;
        ScoreTeam2 = 0;
        UpdateScoreText();
    }

    public void AddScore(int team)
    {
        if(team == 1)
        {
            ScoreTeam1++;
        }
        else
        {
            ScoreTeam2++;
        }
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        ScoreTextTeam1.text = "Team 1: " + ScoreTeam1;
        ScoreTextTeam2.text = "Team 2: " + ScoreTeam2;
    }
}
