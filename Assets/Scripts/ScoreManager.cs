using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int punts;
    private Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        CoinPickup.OnCoinCollected += UpdateScore;
    }

    private void OnDisable()
    {
        CoinPickup.OnCoinCollected -= UpdateScore;
    }

    private void UpdateScore(CoinPickup coin)
    {
        punts += coin.Value;
        scoreText.text = "Score: " + punts.ToString();
    }
}
