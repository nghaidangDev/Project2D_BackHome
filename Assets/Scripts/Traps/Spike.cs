using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthBarUI.instance.TakeDamage(20);
            if (HealthBarUI.instance.currentHealth <= 0)
            {
                PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
                Destroy(playerMovement.gameObject);
            }
        }
    }
}
