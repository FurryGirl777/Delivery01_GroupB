using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int punts;
    private Text scoreText;

    private AudioSource meow;

    private void Start()
    {
        meow = GetComponent<AudioSource>();
    }

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
        meow.Play();
        scoreText.text = "Score: " + punts.ToString();
    }
}
