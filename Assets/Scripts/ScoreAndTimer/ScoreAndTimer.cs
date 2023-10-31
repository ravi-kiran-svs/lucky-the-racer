using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreAndTimer : MonoSingleton<ScoreAndTimer> {

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Slider timerbar;

    [SerializeField] private GameObject scoreUI;
    [SerializeField] private GameObject timerUI;
    [SerializeField] private GameObject gameoverUI;

    private int score = 0;
    private int scorePerPolice = 10;

    private float tStart;
    private float totalTime = 200;

    public bool isGameOver = false;

    private void Start() {
        Time.timeScale = 1;

        PoliceService.Instance.OnPoliceCarDead += OnPoliceCarDead;

        AddScoreAndUpdate(0);

        tStart = Time.time;
    }

    private void Update() {
        float timePassed = Time.time - tStart;
        float timeLeft = totalTime - timePassed;

        timerText.text = ((int)timeLeft).ToString();
        timerbar.value = timePassed / totalTime;

        if (timeLeft <= 0) {
            GameOver();
        }
    }

    private void OnPoliceCarDead() {
        AddScoreAndUpdate(scorePerPolice);
    }

    private void AddScoreAndUpdate(int n) {
        score += n;
        scoreText.text = score.ToString();
    }

    private void GameOver() {
        isGameOver = true;

        timerUI.SetActive(false);
        gameoverUI.SetActive(true);

        Time.timeScale = 0;
    }

    public void OnReplay() {
        SceneManager.LoadScene(0);
    }

}
