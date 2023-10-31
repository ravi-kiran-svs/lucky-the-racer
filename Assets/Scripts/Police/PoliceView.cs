using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceView : MonoBehaviour {

    public event Action<int> OnDeath;

    [SerializeField] ParticleSystem deathParticles;

    [SerializeField] public int id = 0;
    [SerializeField] private float crashSpeed = 20;
    [SerializeField] private float timeToDie = 1;

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Racer")) {
            if (collision.relativeVelocity.magnitude >= crashSpeed) {
                deathParticles.Play();
                StartCoroutine(Die());
            }
        }
    }

    private IEnumerator Die() {
        yield return new WaitForSeconds(timeToDie);
        OnDeath?.Invoke(id);
        Destroy(gameObject);
    }

}
