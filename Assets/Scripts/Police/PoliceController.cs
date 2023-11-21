using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController {

    //private PoliceModel model;
    private PoliceView view;

    [SerializeField] public int id = 0;
    [SerializeField] private float crashSpeed = 20;
    [SerializeField] private float timeToDie = 1;

    public PoliceController(PoliceView policeView) {
        view = policeView;
        policeView.SetController(this);
    }

    public void OnCollisionWithRacer(Collision collision) {
        if (collision.relativeVelocity.magnitude >= crashSpeed) {
            //view.Die(id, timeToDie);
            view.StartCoroutine(view.Die(id, timeToDie));
        }
    }

}
