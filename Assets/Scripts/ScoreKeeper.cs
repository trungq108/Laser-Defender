using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;

    public int ReturnScore()
    {
        return score;
    }

    public void AddScore(int points)
    {
        score += points;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }

}
