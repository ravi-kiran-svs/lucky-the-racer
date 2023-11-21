using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceView : MonoBehaviour {

    private PoliceController controller;

    public event Action<int> OnDeath;

    public ParticleSystem deathParticles;
    public AudioSource crashSound;

    private void Start() {
        deathParticles = GetComponent<ParticleSystem>();
        crashSound = GetComponent<AudioSource>();
    }

    public void SetController(PoliceController policeController) {
        controller = policeController;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Racer")) {
            controller.OnCollisionWithRacer(collision);
        }
    }

    public IEnumerator Die(int id, float t) {
        deathParticles.Play();
        crashSound.Play();

        yield return new WaitForSeconds(t);
        OnDeath?.Invoke(id);
        Destroy(gameObject);
    }

}
