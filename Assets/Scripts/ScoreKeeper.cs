using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;
    static ScoreKeeper instance;

    private void Awake()
    {
        if(instance != null) 
        {
            this.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else 
        { 
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
    }

    public int ReturnScore()
    {
        return score;
    }

    public void AddScore(int points)
    {
        score += points;
        Mathf.Clamp(score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        score = 0;
    }

}
