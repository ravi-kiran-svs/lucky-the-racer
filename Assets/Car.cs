using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Car : MonoBehaviour {

    [SerializeField] private float topSpeed = 30;
    [SerializeField] private float forwardAcc = 30;
    [SerializeField] private float turnControl = 100;

    private float revRatio = 0.7f;
    private float turnThresholdVel = 1;

    [SerializeField] private TextMeshProUGUI speedText;

    private Rigidbody rigid;

    private void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        // this handles forward acceleration.
        if (Input.GetKey(KeyCode.UpArrow)) {
            if (rigid.velocity.magnitude < topSpeed) {
                rigid.AddForce(transform.forward * forwardAcc, ForceMode.Acceleration);
            }
        }

        // this handles backward movement
        if (Input.GetKey(KeyCode.DownArrow)) {
            if (rigid.velocity.magnitude < topSpeed * revRatio || Vector3.Dot(transform.forward, rigid.velocity) >= 0) {
                rigid.AddForce(-transform.forward * forwardAcc * revRatio, ForceMode.Acceleration);
            }
        }

        // this handles turning.
        float dir = Input.GetAxis("Horizontal");
        if (rigid.velocity.magnitude > turnThresholdVel) {
            transform.Rotate(transform.up, turnControl * dir * Time.deltaTime);
        }

        // this negates the sideward velocity during turning.
        rigid.velocity -= transform.right * Vector3.Dot(transform.right, rigid.velocity);
    }

    private void Update() {
        speedText.text = ((int)rigid.velocity.magnitude).ToString();
    }

}
