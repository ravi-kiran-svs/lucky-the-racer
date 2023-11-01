using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RacerView : MonoBehaviour {

    private RacerController controller;

    [SerializeField] public Transform camFollow;
    [SerializeField] public TextMeshProUGUI speedText;
    public AudioSource engineSound;

    private void Start() {
        engineSound = GetComponent<AudioSource>();
    }

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
            controller.keys.forward = Input.GetKey(KeyCode.UpArrow);
            controller.keys.bacward = Input.GetKey(KeyCode.DownArrow);
            controller.keys.hori = Input.GetAxis("Horizontal");

            controller.Ping();
        }
    }

}
