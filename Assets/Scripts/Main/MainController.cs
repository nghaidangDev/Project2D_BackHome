using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [Header("Play Button")]
    [SerializeField] private Image playPanel;
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnPlay_Exit;

    private void Start()
    {
        btnPlay.onClick.AddListener(PlayButton);
        btnPlay_Exit.onClick.AddListener(ExitPanel);
    }

    private void PlayButton()
    {
        playPanel.gameObject.SetActive(true);
    }

    private void ExitPanel()
    {
        playPanel.gameObject.SetActive(false);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
