using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            CoinUI.instance.AddCoin(100);
            Destroy(collision.gameObject);
        }else if (collision.gameObject.CompareTag("Trap"))
        {
            HealthBarUI.instance.TakeDamage(20);
        }
    }
}
