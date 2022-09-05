using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataSaveLoad : MonoBehaviour
{
    [SerializeField] private Transform _savingEnvironment;
    List<Transform> objects = new List<Transform>();

    void Awake()
    {
        LoadScene();
    }

   public void SaveScene()
   {
       objects = GetObjects();
       BinarySave.SaveScene(objects);
   }

   public void LoadScene()
   {
    SceneData data = BinarySave.LoadScene();
    if (data != null)
    {
        for (int i = 0; i<= _savingEnvironment.childCount-1; i++)
        {
            Destroy(_savingEnvironment.GetChild(i).gameObject);
        }

        for (int i = 0; i <= data.objectsPosition.Count-1; i++)
        {
            Item prefab = Resources.Load<Item>(data.objectName[i]);
            Transform newObject = Instantiate(prefab.itemPrefab, new Vector3(data.objectsPosition[i].x, data.objectsPosition[i].y, data.objectsPosition[i].z), new Quaternion(data.objectsRotation[i].x, data.objectsRotation[i].y, data.objectsRotation[i].z, data.objectsRotation[i].w));
            newObject.SetParent(_savingEnvironment);
        }
    }
   }

   private List<Transform> GetObjects()
   {
       objects.Clear();
        for (int i = 0;  i <= _savingEnvironment.childCount-1; i++)
        {
            Transform currentObject = _savingEnvironment.GetChild(i);
            objects.Add(currentObject);
        }
        return objects;
   }
}
