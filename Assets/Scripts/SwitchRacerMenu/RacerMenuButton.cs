using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RacerMenuButton : MonoBehaviour {

    [SerializeField] private RacerModel stats;

    [SerializeField] private Slider[] sliders;
    [SerializeField] private TextMeshProUGUI[] compareTexts;

    private void Start() {
        SwitchRacerMenu.Instance.OnMenuOpen += SetCompares;

        SetSliders();
        SetCompares(RacerService.Instance.GetCurrentRacerStats());
    }

    private void SetSliders() {
        sliders[0].value = Mathf.InverseLerp(0, 50, stats.topSpeed);
        sliders[1].value = Mathf.InverseLerp(0, 50, stats.forwardAcc);
        sliders[2].value = Mathf.InverseLerp(0, 100, stats.turnControl);
    }

    private void SetCompares(RacerModel currentRacer) {
        float compare = stats.topSpeed - currentRacer.topSpeed;
        if (compare > 0) {
            compareTexts[0].text = "+" + compare.ToString();
        } else if (compare == 0) {
            compareTexts[0].text = "=";
        } else {
            compareTexts[0].text = compare.ToString();
        }

        compare = stats.forwardAcc - currentRacer.forwardAcc;
        if (compare > 0) {
            compareTexts[1].text = "+" + compare.ToString();
        } else if (compare == 0) {
            compareTexts[1].text = "=";
        } else {
            compareTexts[1].text = compare.ToString();
        }

        compare = stats.turnControl - currentRacer.turnControl;
        if (compare > 0) {
            compareTexts[2].text = "+" + compare.ToString();
        } else if (compare == 0) {
            compareTexts[2].text = "=";
        } else {
            compareTexts[2].text = compare.ToString();
        }
    }

}
