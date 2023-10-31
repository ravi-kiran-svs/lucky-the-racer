using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreAndTimer : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    private void Start() {
        PoliceService.Instance.OnPoliceCarDead += OnPoliceCarDead;

        AddScoreAndUpdate(0);
    }

    private void OnPoliceCarDead() {
        AddScoreAndUpdate(10);
    }

    private void AddScoreAndUpdate(int n) {
        score += n;
        scoreText.text = score.ToString();
    }

}
