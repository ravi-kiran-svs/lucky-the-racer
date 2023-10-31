using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndTimer : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Slider timerbar;

    private int score = 0;
    private int scorePerPolice = 10;

    private float tStart;
    private float totalTime = 200;

    private void Start() {
        PoliceService.Instance.OnPoliceCarDead += OnPoliceCarDead;

        AddScoreAndUpdate(0);

        tStart = Time.time;
    }

    private void Update() {
        float timePassed = Time.time - tStart;
        float timeLeft = totalTime - timePassed;

        timerText.text = ((int)timeLeft).ToString();
        timerbar.value = timePassed / totalTime;
    }

    private void OnPoliceCarDead() {
        AddScoreAndUpdate(scorePerPolice);
    }

    private void AddScoreAndUpdate(int n) {
        score += n;
        scoreText.text = score.ToString();
    }

}
