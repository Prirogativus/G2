using UnityEngine;

[CreateAssetMenu(fileName = "New Ship Stats", menuName = "Ship Stats")]
public class ShipStats : ScriptableObject
{
    public string name;
    public int shipType;
    public int loadCapacity;
    public int price;
    public float speed;
    public float supplyLimit;
}
