using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerController {

    private RacerModel model;
    private RacerView view;

    public RacerKeys keys = new RacerKeys();
    private float revRatio = 0.7f;
    private float turnThresholdVel = 10;
    private float speedUIThreshold = 10;

    private Rigidbody rigid;

    public RacerController(RacerModel racerModel, RacerView racerView) {
        model = racerModel;

        view = racerView;
        racerView.SetController(this);
        Cam.Instance.SetFollow(view.camFollow);
        rigid = view.GetComponent<Rigidbody>();
    }

    public void PhysicsPing() {
        Cam.Instance.vibrate = keys.forward && keys.bacward;

        if (keys.forward && !keys.bacward) {
            if (rigid.velocity.magnitude < model.topSpeed) {
                rigid.AddForce(view.transform.forward * model.forwardAcc, ForceMode.Acceleration);
            }

        } else if (keys.bacward && !keys.forward) {
            if (rigid.velocity.magnitude < model.topSpeed * revRatio || Vector3.Dot(view.transform.forward, rigid.velocity) >= 0) {
                rigid.AddForce(model.forwardAcc * revRatio * -view.transform.forward, ForceMode.Acceleration);
            }
        }

        float turnDir = Mathf.Clamp(Vector3.Dot(view.transform.forward, rigid.velocity) / turnThresholdVel, -1, 1);
        view.transform.Rotate(view.transform.up, model.turnControl * keys.hori * Time.deltaTime * turnDir);

        rigid.velocity -= view.transform.right * Vector3.Dot(view.transform.right, rigid.velocity);
    }

    public void Ping() {
        int speed = (int)(Vector3.Dot(view.transform.forward, rigid.velocity) * 2) * 5;
        if (model.topSpeed * 10 - speed < speedUIThreshold) {
            speed = (int)(model.topSpeed * 10);
        }
        if (speed < 0) {
            speed *= -1;
        }

        view.speedText.text = speed.ToString();
    }

    public void DestroySelf() {
        GameObject.Destroy(view.gameObject);
    }
}
