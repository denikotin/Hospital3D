using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTabGridButton : MonoBehaviour
{
    public Building buildScript;
    public Raycasting raycast;
    public Item[] itemListCommon;
    public List<Item> itemListBathroom;
    public List<Item> itemListBeds;
    public List<Item> itemListChairs;
    public List<Item> itemListClosets;
    public List<Item> itemListMachines;
    public List<Item> itemListProops;
    public List<Item> itemListTables;
    public GameObject Bathroom,Beds,Chairs,Closets,Machines,Proops,Tables;
    public GameObject prefabUIElement;
    private GameObject createdElement;

    public void Start()
    {
        LoadItems();
        CreateUIElements(itemListBathroom, Bathroom);
        CreateUIElements(itemListBeds, Beds);
        CreateUIElements(itemListChairs, Chairs);
        CreateUIElements(itemListClosets, Closets);
        CreateUIElements(itemListMachines, Machines);
        CreateUIElements(itemListProops, Proops);
        CreateUIElements(itemListTables, Tables);
    }

    public void LoadItems()
    {
        itemListCommon = Resources.LoadAll<Item>("");
        foreach(var itemInfo in itemListCommon)
        {
            switch(itemInfo.itemType)
            {
                case "Bathroom":
                itemListBathroom.Add(itemInfo);
                break;

                case "Beds":
                itemListBeds.Add(itemInfo);
                break;

                case "Chairs":
                itemListChairs.Add(itemInfo);
                break;

                case "Closets":
                itemListClosets.Add(itemInfo);
                break;

                case "Machines":
                itemListMachines.Add(itemInfo);
                break;

                case "Proops":
                itemListProops.Add(itemInfo);
                break;

                case "Tables":
                itemListTables.Add(itemInfo);
                break;
            }
        }
        
    }

    public  void CreateUIElements(List<Item> listItems, GameObject TabGroup)
    {
        for (int i = 0; i <= listItems.Count-1; i++)
        {
            createdElement = Instantiate(prefabUIElement, TabGroup.transform.position, TabGroup.transform.rotation);
            createdElement.GetComponentInChildren<Text>().text = listItems[i].itemName;
            createdElement.transform.Find("Code").GetComponent<Text>().text = listItems[i].itemCode;
            createdElement.transform.Find("Image").GetComponent<Image>().sprite = listItems[i].itemIcon;
            createdElement.transform.GetComponent<GridButtonAction>().buildScript = buildScript;
            createdElement.transform.GetComponent<GridButtonAction>().raycasting = raycast;
            createdElement.transform.SetParent(TabGroup.transform);
        }
    }

}


