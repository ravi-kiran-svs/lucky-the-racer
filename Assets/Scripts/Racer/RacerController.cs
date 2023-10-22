using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerController {

    // part of RacerModel
    [SerializeField] private float topSpeed = 30;
    [SerializeField] private float forwardAcc = 30;
    [SerializeField] private float turnControl = 50;

    // private RacerModel model;
    private RacerView view;

    public RacerKeys keys = new RacerKeys();
    private float revRatio = 0.7f;
    private float turnThresholdVel = 10;

    private Rigidbody rigid;

    public RacerController(RacerView racerView) {
        view = racerView;
        racerView.SetController(this);
        Cam.Instance.SetFollow(view.camFollow);
        rigid = view.GetComponent<Rigidbody>();
    }

    public void PhysicsPing() {
        Cam.Instance.vibrate = keys.forward && keys.bacward;

        if (keys.forward && !keys.bacward) {
            if (rigid.velocity.magnitude < topSpeed) {
                rigid.AddForce(view.transform.forward * forwardAcc, ForceMode.Acceleration);
            }

        } else if (keys.bacward && !keys.forward) {
            if (rigid.velocity.magnitude < topSpeed * revRatio || Vector3.Dot(view.transform.forward, rigid.velocity) >= 0) {
                rigid.AddForce(forwardAcc * revRatio * -view.transform.forward, ForceMode.Acceleration);
            }
        }

        float dir = Mathf.Clamp(Vector3.Dot(view.transform.forward, rigid.velocity) / turnThresholdVel, -1, 1);
        view.transform.Rotate(view.transform.up, turnControl * keys.hori * Time.deltaTime * dir);

        // this negates the sideward velocity during turning.
        rigid.velocity -= view.transform.right * Vector3.Dot(view.transform.right, rigid.velocity);
    }

    public void Ping() {
        //speedText.text = ((int)rigid.velocity.magnitude).ToString();
    }
}
