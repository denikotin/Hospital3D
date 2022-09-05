using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridButtonAction : MonoBehaviour, IPointerClickHandler
{
    public Building buildScript;
    private Transform prefab;
    public Raycasting raycasting;

    public void OnPointerClick(PointerEventData eventData)
    {
        Item[] itemList = Resources.LoadAll<Item>("");
        string itemCodePrefab = transform.Find("Code").GetComponent<Text>().text;
        foreach(Item item in itemList)
        {
            if (item.itemCode == itemCodePrefab)
            {
                prefab = item.itemPrefab;
                buildScript.StartInstantiate(prefab);
            }
        }
        
    }
}
