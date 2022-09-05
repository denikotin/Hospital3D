using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneData
{
    public List<NewVector3> objectsPosition = new List<NewVector3>();
    public List<NewQuaternion> objectsRotation = new List<NewQuaternion>();
    public List<string> objectName = new List<string>();

    public SceneData(List<Transform> objects)
    {
        for (int i=0; i<= objects.Count-1; i++)
        {
            Transform currentObject = objects[i];
            var currentPosition = currentObject.position;
            var currentRotation= currentObject.rotation;
            var currentName  = currentObject.GetComponent<ItemDefinition>().item.itemCode;
            objectsPosition.Add(new NewVector3(currentPosition.x, currentPosition.y, currentPosition.z));
            objectsRotation.Add(new NewQuaternion(currentRotation.x, currentRotation.y, currentRotation.z, currentRotation.w));
            objectName.Add(currentObject.GetComponent<ItemDefinition>().item.itemCode);
            Debug.Log(currentName);
        }
    }


    [System.Serializable]
    public class NewVector3
    {
        public float x;
        public float y;
        public float z;

        public NewVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [System.Serializable]
    public class NewQuaternion
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public NewQuaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    
    }
}
