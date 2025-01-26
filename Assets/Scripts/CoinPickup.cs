using System;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int Value = 5;
    public static Action<CoinPickup> OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Gato")
        {
            OnCoinCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
