using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceView : MonoBehaviour {

    [SerializeField] float crashSpeed = 20;

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Racer")) {
            if (collision.relativeVelocity.magnitude >= crashSpeed) {
                Debug.Log("yusshh");
            }
        }
    }

}
