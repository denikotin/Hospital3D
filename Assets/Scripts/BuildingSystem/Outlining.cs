using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outlining : MonoBehaviour
{
    public Raycasting raycasting;
    private Outline currentOutline;
    private Object currentObject;

    public void Outline(Outline outline)
    {
        if (outline)
        {
          if (currentOutline && currentOutline != outline)
          {
              currentOutline.OutlineWidth = 0;
          }
          currentObject = raycasting.hit.transform.GetComponent<Object>();
          currentOutline = outline;
          outline.OutlineWidth = 4;  
        }
        else
        {
            if (currentOutline)
            {
                currentOutline.OutlineWidth = 0;
                currentOutline = null;
                currentObject = null;
            }
        }
    }
}

