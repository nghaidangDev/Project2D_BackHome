using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public static HealthBarUI instance;
    [SerializeField] private Image currentHealthImg;
    private float currentHealth = 100;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        UpdateHealthCurrent();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthCurrent();
    }

    private void UpdateHealthCurrent()
    {
        currentHealthImg.fillAmount = currentHealth / 100;
    }
}
