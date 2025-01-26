using System;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static Action<PowerUp> OnPowerUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Gato")
        {
             OnPowerUp?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
