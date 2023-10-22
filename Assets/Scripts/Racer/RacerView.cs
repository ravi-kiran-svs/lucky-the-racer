using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RacerView : MonoBehaviour {

    private RacerController controller;

    public void SetController(RacerController racerController) {
        controller = racerController;
    }

    private void FixedUpdate() {
        if (controller != null) {
            controller.PhysicsPing();
        }
    }

    private void Update() {
        if (controller != null) {
            controller.Ping();
        }
    }

}
