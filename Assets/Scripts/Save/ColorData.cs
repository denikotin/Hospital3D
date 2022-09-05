using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorData
{
    public List<NewColor> buildingsColor = new List<NewColor>();

    public ColorData(List<Color> colors)
    {
        for (int i = 0; i<= colors.Count-1; i++)
        {
            Color currentColor = colors[i];
            float currentRColor = currentColor.r;
            float currentGColor = currentColor.g;
            float currentBColor = currentColor.b;
            buildingsColor.Add(new NewColor(currentRColor, currentGColor, currentBColor));
        }

    }


    [System.Serializable]
    public class NewColor
    {
        public float RColor;
        public float GColor;
        public float BColor;

        public NewColor(float R, float G, float B)
        {
            this.RColor = R;
            this.GColor = G;
            this.BColor = B;
        }
    }
}
