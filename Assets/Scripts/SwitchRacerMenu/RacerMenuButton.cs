using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacerMenuButton : MonoBehaviour {

    [SerializeField] private RacerModel stats;

    [SerializeField] private Slider[] sliders;

    private void Awake() {
        SetSliders();
    }

    private void SetSliders() {
        sliders[0].value = Mathf.InverseLerp(0, 50, stats.topSpeed);
        sliders[1].value = Mathf.InverseLerp(0, 50, stats.forwardAcc);
        sliders[2].value = Mathf.InverseLerp(0, 100, stats.turnControl);
    }

}
