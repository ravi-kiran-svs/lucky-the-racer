using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeRacerView : MonoBehaviour {

    [SerializeField] int id = 0;

    private bool isCarIn = false;

    private void Update() {
        if (isCarIn && Input.GetKeyDown(KeyCode.F)) {
            RacerService.Instance.SwitchRacer(id);
        }
    }

    private void OnTriggerEnter(Collider other) {
        isCarIn = true;
    }

    private void OnTriggerExit(Collider other) {
        isCarIn = false;
    }

}
