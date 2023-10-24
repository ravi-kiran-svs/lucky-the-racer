using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerService : MonoSingleton<RacerService> {

    [SerializeField] private RacerView[] racerViews;

    [SerializeField] private RacerModel[] racerModels;

    [SerializeField] private Transform spawnPoints;

    private RacerController currentRacer;

    private void Start() {
        SpawnRacer(0);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SwitchRacer(Random.Range(0, 4));
        }
    }

    private void SwitchRacer(int id) {
        currentRacer.DestroySelf();

        SpawnRacer(id);
    }

    private void SpawnRacer(int id) {
        RacerConfig config = spawnPoints.GetChild(id).GetComponent<RacerConfig>();
        Transform p = config.transform;
        RacerModel model = config.model;
        RacerView view = Instantiate(config.view, p.position, p.rotation, transform);
        currentRacer = new RacerController(model, view);
    }

}
