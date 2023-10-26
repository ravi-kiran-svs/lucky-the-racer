using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerService : MonoSingleton<RacerService> {

    public event Action<RacerModel> OnNewRacer;

    [SerializeField] private RacerView[] racerViews;

    [SerializeField] private RacerModel[] racerModels;

    [SerializeField] private Transform spawnPoints;

    private RacerController currentRacer;

    private void Start() {
        SpawnRacer(0);
    }

    public void SwitchRacer(int id) {
        currentRacer.DestroySelf();
        SpawnRacer(id);
    }

    private void SpawnRacer(int id) {
        RacerConfig config = spawnPoints.GetChild(id).GetComponent<RacerConfig>();
        Transform p = config.transform;
        RacerModel model = config.model;
        RacerView view = Instantiate(config.view, p.position, p.rotation, transform);
        currentRacer = new RacerController(model, view);

        OnNewRacer?.Invoke(model);
    }

    public RacerModel GetCurrentRacerStats() {
        return currentRacer.GetStats();
    }

}
