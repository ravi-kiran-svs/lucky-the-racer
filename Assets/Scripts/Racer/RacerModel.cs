using UnityEngine;

[CreateAssetMenu(fileName = "RacerModel", menuName = "ScriptableObjects/CreateRacerModel")]

public class RacerModel : ScriptableObject {
    [SerializeField] public float topSpeed = 30;
    [SerializeField] public float forwardAcc = 30;
    [SerializeField] public float turnControl = 50;
}
