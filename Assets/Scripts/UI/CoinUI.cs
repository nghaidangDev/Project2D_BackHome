using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public static CoinUI instance;
    [SerializeField] private TMP_Text textCoin;
    private int coin = 0;

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
        UpdateTextCoin();
    }

    public void AddCoin(int addcoin)
    {
        coin += addcoin;
        UpdateTextCoin();
    }

    private void UpdateTextCoin()
    {
        textCoin.text = "SCORE: " + coin.ToString();
    }
}
