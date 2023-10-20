using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

    [SerializeField] Transform follow;

    private void Update() {
        transform.position = follow.position;
        transform.rotation = follow.rotation;
    }

}
