using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceView : MonoBehaviour {

    [SerializeField] ParticleSystem deathParticles;

    [SerializeField] float crashSpeed = 20;
    [SerializeField] float timeToDie = 1;

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
        Destroy(gameObject);
    }

}
