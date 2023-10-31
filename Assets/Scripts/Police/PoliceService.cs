using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceService : MonoSingleton<PoliceService> {

    [SerializeField] PoliceView prefabs;

    private void Start() {
        for (int i = 0; i < transform.childCount; i++) {
            StartCoroutine(SpawnPoliceCarAt(i, transform.GetChild(i), 0));
        }
    }

    private IEnumerator SpawnPoliceCarAt(int id, Transform parent, int time) {
        yield return new WaitForSeconds(time);
        PoliceView view = Instantiate(prefabs, parent.position, parent.rotation, parent);

        view.id = id;
        view.OnDeath += OnPoliceDeath;
    }

    private void OnPoliceDeath(int id) {
        StartCoroutine(SpawnPoliceCarAt(id, transform.GetChild(id), 5));
    }

}
