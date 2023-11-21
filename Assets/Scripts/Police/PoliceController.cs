using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController {

    private PoliceModel model;
    private PoliceView view;

    private int id = 0;

    public PoliceController(int id, PoliceModel policeModel, PoliceView policeView) {
        model = policeModel;
        view = policeView;
        policeView.SetController(this);
    }

    public void OnCollisionWithRacer(Collision collision) {
        if (collision.relativeVelocity.magnitude >= model.crashSpeed) {
            view.StartCoroutine(view.Die(id, model.timeToDie));
        }
    }

}
