using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

[System.Serializable]
public static class BinarySave
{
    public static void SaveScene(List<Transform> parentObject)
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string directory = Application.dataPath+"/saves";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        string path = directory+$"/SceneSave_{sceneName}.nktn";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        SceneData data = new SceneData(parentObject);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SceneData LoadScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string directory = Application.dataPath+"/saves";
        string path = directory+$"/SceneSave_{sceneName}.nktn";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SceneData data = formatter.Deserialize(stream) as SceneData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found " + path);
            return null;
        }
    }


    public static void SaveColor(List<Color> colors)
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string directory = Application.dataPath+"/saves";
        if(!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        string path = directory+$"/ColorSave_{sceneName}.nktn";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        ColorData data = new ColorData(colors);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ColorData LoadColor()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string directory = Application.dataPath+"/saves";
        string path = directory+$"/ColorSave_{sceneName}.nktn";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ColorData data = formatter.Deserialize(stream) as ColorData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found" + path);
            return null;
        }
    }

}
