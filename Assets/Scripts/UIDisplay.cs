using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text textScore;
    [SerializeField] Slider healthBar;
    [SerializeField] Health playerHelth;
    ScoreKeeper scoreKeeper;
    
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        healthBar.maxValue = playerHelth.GetHealthNumber();
    }

    private void Update()
    {
        textScore.text = scoreKeeper.ReturnScore().ToString("000000000");
        healthBar.value = playerHelth.GetHealthNumber();
    }

}
