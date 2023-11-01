using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceView : MonoBehaviour {

    public event Action<int> OnDeath;

    public ParticleSystem deathParticles;
    public AudioSource crashSound;

    [SerializeField] public int id = 0;
    [SerializeField] private float crashSpeed = 20;
    [SerializeField] private float timeToDie = 1;

    private void Start() {
        deathParticles = GetComponent<ParticleSystem>();
        crashSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Racer")) {
            if (collision.relativeVelocity.magnitude >= crashSpeed) {
                StartCoroutine(Die());
            }
        }
    }

    private IEnumerator Die() {
        deathParticles.Play();
        crashSound.Play();

        yield return new WaitForSeconds(timeToDie);
        OnDeath?.Invoke(id);
        Destroy(gameObject);
    }

}
