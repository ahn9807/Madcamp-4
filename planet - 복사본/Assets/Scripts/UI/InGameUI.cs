﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public GameObject ingamePanel;
    public GameObject pausePanel;
    public GameObject endPanel;
    public GameObject loading;
    public Text loadingText;
    public GameObject button_1;
    public GameObject button_2;
    public Button restartButton;
    public Button menuButton;
    public Text endsScoreText;
    public Image jumpImage;
    public Text jumpText;

    private void Start()
    {
        ActivatePause();
        loading.SetActive(true);
        button_1.SetActive(false);
        button_2.SetActive(false);
        StartCoroutine(IELoading());

        restartButton.onClick.AddListener(ReloadScene);
        menuButton.onClick.AddListener(LoadMainMenu);

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("Title");
    }

    IEnumerator IELoading()
    {
        Time.timeScale = 0;
        loadingText.text = "냇가와 잔디 심는 중...";
        yield return new WaitForSecondsRealtime(1);
        loadingText.text = "나무 심는 중...";
        yield return new WaitForSecondsRealtime(2);
        loadingText.text = "토끼 번식 중 ?...";
        yield return new WaitForSecondsRealtime(2);
        loadingText.text = "여우 무리 생성중 ?...";
        yield return new WaitForSecondsRealtime(2);
        loadingText.text = "맵 생성 완료중...";
        yield return new WaitForSecondsRealtime(1);
        loading.SetActive(false);
        button_1.SetActive(true);
        button_2.SetActive(true);
        Time.timeScale = 1;
        ActivateInGame();
    }

    void ActivatePause()
    {
        ingamePanel.SetActive(false);
        pausePanel.SetActive(true);
        endPanel.SetActive(false);
    }

    void ActivateInGame()
    {
        ingamePanel.SetActive(true);
        pausePanel.SetActive(false);
        endPanel.SetActive(false);
    }

    public void ActivateEndGame()
    {
        ingamePanel.SetActive(false);
        pausePanel.SetActive(false);
        endPanel.SetActive(true);
    }
}
