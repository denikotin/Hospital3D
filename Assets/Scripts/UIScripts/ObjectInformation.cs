using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInformation : MonoBehaviour
{
    public GameObject objectInfoUI;
    public Raycasting raycasting;
    private Item item;

    void Start()
    {
        objectInfoUI.SetActive(false);
    }

    void Update()
    {
        if (raycasting.hit.collider)
        {
            if (raycasting.hit.collider.gameObject.layer == 7)
            {
                item = raycasting.hit.collider.gameObject.GetComponent<ItemDefinition>().item;
                int itemToBuy = item.itemCount - item.itemBalance;
                double totalPrice = itemToBuy * item.itemPrice;
                if (item.itemBalance == 0)
                {
                    objectInfoUI.transform.Find("Info").Find("Balance").Find("BalanceDescription").GetComponent<Text>().color = Color.red;
                }
                objectInfoUI.transform.Find("Info").Find("Name").Find("NameDescription").GetComponent<Text>().text = item.itemName;
                objectInfoUI.transform.Find("Info").Find("Model").Find("ModelDescription").GetComponent<Text>().text = item.itemModel;
                objectInfoUI.transform.Find("Info").Find("Size").Find("SizeDescription").GetComponent<Text>().text = item.itemSize;
                objectInfoUI.transform.Find("Info").Find("Count").Find("CountDescription").GetComponent<Text>().text = item.itemCount.ToString();
                objectInfoUI.transform.Find("Info").Find("Balance").Find("BalanceDescription").GetComponent<Text>().text = item.itemBalance.ToString();
                objectInfoUI.transform.Find("Info").Find("Price").Find("PriceDescription").GetComponent<Text>().text = item.itemPrice.ToString() + " руб.";
                objectInfoUI.transform.Find("Info").Find("Code").Find("CodeDescription").GetComponent<Text>().text = item.itemCode;
                objectInfoUI.transform.Find("Info").Find("InTotal").Find("NeedToBuyDescription").GetComponent<Text>().text = itemToBuy.ToString() + " единиц";
                objectInfoUI.transform.Find("Info").Find("InTotal").Find("SummDescription").GetComponent<Text>().text = totalPrice.ToString() + " руб.";
                objectInfoUI.SetActive(true);
            }
            else
            {
                objectInfoUI.SetActive(false);
            }
        }
    }
}
