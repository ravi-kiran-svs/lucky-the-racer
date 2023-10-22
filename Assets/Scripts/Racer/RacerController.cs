using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerController {

    // part of RacerModel
    [SerializeField] private float topSpeed = 30;
    [SerializeField] private float forwardAcc = 30;
    [SerializeField] private float turnControl = 100;

    private float revRatio = 0.7f;
    private float turnThresholdVel = 0;

    private Rigidbody rigid;

    // private RacerModel model;
    private RacerView view;

    public RacerController(RacerView racerView) {
        view = racerView;
        racerView.SetController(this);
        rigid = view.GetComponent<Rigidbody>();
    }

    public void PhysicsPing() {
        // this handles forward acceleration.
        /*if (Input.GetKey(KeyCode.UpArrow)) {
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
        rigid.velocity -= transform.right * Vector3.Dot(transform.right, rigid.velocity);*/
    }

    public void Ping() {
        //speedText.text = ((int)rigid.velocity.magnitude).ToString();
    }
}
