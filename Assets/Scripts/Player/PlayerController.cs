using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private int coinAmount;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            CoinUI.instance.AddCoin(100);
            Destroy(collision.gameObject);
            coinAmount++;

        }else if (collision.gameObject.CompareTag("Trap"))
        {
            HealthBarUI.instance.TakeDamage(20);
            if (anim != null)
            {
                anim.SetTrigger("hit");
            }

            if (HealthBarUI.instance.currentHealth <= 0)
            {
                PlayerMovement.Destroy(gameObject);
            }
        }else if (collision.gameObject.CompareTag("WinPoint"))
        {
            if (coinAmount == 4)
            {
                UIController.instance.WinGame();
                PlayerMovement.Destroy(gameObject);
            }
        }
    }
}
