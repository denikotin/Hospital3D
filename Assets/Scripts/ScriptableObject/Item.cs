using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New ItemData", menuName = "Create Item/New Item")]
public class Item : ScriptableObject
{
    public string itemType;
    public string itemName;
    public string itemModel;
    public string itemSize;
    public int itemCount;
    public int itemBalance;
    public float itemPrice;
    public string itemCode;
    public Transform itemPrefab;
    public Sprite itemIcon;

}
