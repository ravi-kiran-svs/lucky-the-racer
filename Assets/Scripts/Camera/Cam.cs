using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoSingleton<Cam> {

    [SerializeField] private Transform follow;
    [SerializeField] private float vibrateAmount = 0.05f;

    [HideInInspector] public bool vibrate = false;

    public void SetFollow(Transform camFollow) {
        follow = camFollow;
    }

    private void Update() {
        if (follow) {
            transform.position = follow.position;
            transform.rotation = follow.rotation;
        }

        if (vibrate) {
            Vector3 p = transform.position;
            p.x += Random.Range(-vibrateAmount, vibrateAmount);
            p.y += Random.Range(-vibrateAmount, vibrateAmount);
            transform.position = p;
        }
    }

}
