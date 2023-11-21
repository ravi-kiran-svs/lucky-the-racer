using UnityEngine;

[CreateAssetMenu(fileName = "PoliceModel", menuName = "ScriptableObjects/CreatePoliceModel")]

public class PoliceModel : ScriptableObject {
    [SerializeField] public float crashSpeed = 20;
    [SerializeField] public float timeToDie = 1;
}
