using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerService : MonoSingleton<RacerService> {

    [SerializeField] private RacerView[] racerViews;

    private void Start() {
        // remove later
        Destroy(transform.GetChild(0).gameObject);

        SpawnRacer();
    }

    public void SpawnRacer() {
        RacerView view = Instantiate(racerViews[0], transform);
        RacerController controller = new RacerController(view);
    }

}
