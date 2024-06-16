using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] private Image deadImg;
    [SerializeField] private Button restartBtn;

    [Header("Win Game")]
    [SerializeField] private Image winImg;

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
        restartBtn.onClick.AddListener(RestartGame);
    }

    private void Update()
    {
        PlayerDead();
    }

    private void PlayerDead()
    {
        if (HealthBarUI.instance != null && HealthBarUI.instance.currentHealth <= 0)
        {
            deadImg.gameObject.SetActive(true);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void WinGame()
    {
        winImg.gameObject.SetActive(true);
    }
}
