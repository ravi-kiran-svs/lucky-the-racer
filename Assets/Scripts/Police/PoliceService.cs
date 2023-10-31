using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceService : MonoSingleton<PoliceService> {

    [SerializeField] PoliceView prefabs;

    private void Start() {
        for (int i = 0; i < transform.childCount; i++) {
            SpawnPoliceCarAt(transform.GetChild(i));
        }
    }

    private void SpawnPoliceCarAt(Transform parent) {
        Instantiate(prefabs, parent.position, parent.rotation, parent);
    }

}
