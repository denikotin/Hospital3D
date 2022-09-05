using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuAction : MonoBehaviour
{
    [SerializeField] private GameObject _currentFloorUI;
    private int _currentFloor = 1;
    public void NextFloor()
    {
        _currentFloor +=1;
        SetCurrentFloor(_currentFloor);
    }

    public void PreviousFloor()
    {
        _currentFloor -=1;
        SetCurrentFloor(_currentFloor);
    }

    public void SetCurrentFloor(int currentFloor)
    {
        _currentFloorUI.transform.GetComponent<Text>().text = $"{_currentFloor.ToString()}-й этаж"; 
    }

    public int GetCurrentFloor()
    {
        return _currentFloor;
    }

    
    [SerializeField] private GameObject _infoUI;
    public void SetInfo(string name, Sprite sprite)
    {
        _infoUI.transform.Find("Name").GetComponent<Text>().text = name;
        _infoUI.transform.Find("Image").GetComponent<Image>().sprite = sprite;
    }
    public void EnableInfo()
    {
        _infoUI.SetActive(true);
    }

    public void DisableInfo()
    {
        _infoUI.SetActive(false);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
