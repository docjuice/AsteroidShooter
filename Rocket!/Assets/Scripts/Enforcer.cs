using UnityEngine;

[CreateAssetMenu(fileName = "New Enforcer", menuName = "Enforcer")]
public class Enforcer : ScriptableObject {

    public GameObject prefab, pickUpPrefab;
    public new string name;
    public string text;
    public Color color;
}
