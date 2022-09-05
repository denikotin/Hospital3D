using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDataSaveLoad : MonoBehaviour
{
    [SerializeField] private Transform _building;
    private Material[] materials;
    [SerializeField ]private List<Color> colors = new List<Color>();


    void Awake()
    {
        LoadColor();
    }
    public void SaveColor()
    {
        colors = GetColors();
        BinarySave.SaveColor(colors);
    }

    public void LoadColor()
    {
        ColorData data = BinarySave.LoadColor();
        if (data != null)
        {
            for (int i = 0; i<= data.buildingsColor.Count-1; i++)
            {
                _building.GetComponent<MeshRenderer>().materials[i].color = new Color(data.buildingsColor[i].RColor, data.buildingsColor[i].GColor, data.buildingsColor[i].BColor);

            }
        }
    }


    public List<Color> GetColors()
    {
        colors.Clear();
        materials = _building.GetComponent<MeshRenderer>().materials;
        foreach(Material material in materials)
        {
            colors.Add(material.color);
        }
        return colors;
    }


}
