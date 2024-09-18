using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "TDEngine/Item", order = 1)]

public class Item : ScriptableObject
{
    public string identifier;
    public GameObject pickupPrefab;
    public GameObject spawnedPrefab;
}
