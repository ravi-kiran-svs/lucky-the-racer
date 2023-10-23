using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerService : MonoSingleton<RacerService> {

    [SerializeField] private RacerView[] racerViews;

    [SerializeField] private RacerModel[] racerModels;

    [SerializeField] private Transform spawnPoints;

    private void Start() {
        // remove later
        Destroy(transform.GetChild(0).gameObject);

        SpawnRacer();
    }

    public void SpawnRacer() {
        Transform p = spawnPoints.GetChild(0);
        RacerModel model = racerModels[3];
        RacerView view = Instantiate(racerViews[3], p.position, p.rotation, transform);
        RacerController controller = new RacerController(model, view);
    }

}
