using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selectable : MonoBehaviour
{
    [SerializeField] private MenuAction _menu;
    private Item _item;

    public void Select()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 5, transform.position.z), 0.5f);
        _item  = transform.GetComponent<ItemDefinition>().item;
        _menu.SetInfo(_item.itemName, _item.itemIcon);
        _menu.EnableInfo();

    }

    public void Diselect()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 1, transform.position.z), 4f);
        _menu.DisableInfo();
    }    
}
