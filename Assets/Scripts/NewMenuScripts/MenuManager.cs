using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _floorsGO;
    private Dictionary<int,Transform> _floors = new Dictionary<int, Transform>();
    [SerializeField] private NewMenuRaycast _raycasting;
    [SerializeField] private MenuAction _menu;
    private GameObject _currentObject;
    private Selectable _currentSelectable;


    
    private void Start()
    {
        for (int i = 0; i <= _floorsGO.transform.childCount-1; i++ )
        {
            _floors.Add(i+1,_floorsGO.transform.GetChild(i));   
        }
    }

    void Update()
    {
        if(_raycasting.hit.collider != null)
        {
            if (OnMouseMove() && Input.GetMouseButtonDown(0))
            {
                LoadScene();
            }
        }
    }

    private bool OnMouseMove()
    {
        if(_raycasting.hit.collider.transform.GetComponent<Selectable>() != null)
        {
            if(_currentSelectable && _currentSelectable != _raycasting.hit.collider.transform.GetComponent<Selectable>())
            {
                _currentObject.transform.GetComponent<Selectable>().Diselect();
            }
            _currentObject = _raycasting.hit.collider.gameObject;
            _currentSelectable = _raycasting.hit.collider.transform.GetComponent<Selectable>();
            _currentObject.transform.GetComponent<Selectable>().Select();
            return true;
        }
        else
        {
            if(_currentSelectable)
            {
                _currentObject.transform.GetComponent<Selectable>().Diselect();
                _currentSelectable = null;
            }
            return false;
        }
    }

    private void LoadScene()
    {
        int code;
        code = int.Parse(_raycasting.hit.collider.transform.GetComponent<ItemDefinition>().item.itemCode);
        SceneManager.LoadScene(code);
    }


    public void SetNextFloor()
    {
        if (_menu.GetCurrentFloor() < _floors.Count)
        {
            _floors[_menu.GetCurrentFloor()].gameObject.SetActive(false);
            _menu.NextFloor();
            _floors[_menu.GetCurrentFloor()].gameObject.SetActive(true);
        }
    }

    public void SetPreviousFloor()
    {
        if (_menu.GetCurrentFloor() > 1)
        {   
            _floors[_menu.GetCurrentFloor()].gameObject.SetActive(false);
            _menu.PreviousFloor();
            _floors[_menu.GetCurrentFloor()].gameObject.SetActive(true);
        }
    }
}
