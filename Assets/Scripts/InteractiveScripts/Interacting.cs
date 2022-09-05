using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacting : MonoBehaviour
{
    public Raycasting raycasting;
    [SerializeField] GameObject DoorIcon, Crosshair;
    public void Start()
    {
        DoorIcon.SetActive(false);
        
    }

    public void Update()
    {
        DoorInteract();
    }


    private void DoorInteract()
    {
        if ( raycasting.hit.transform != null && raycasting.hit.transform.GetComponent<Door>())
        {
            DoorIcon.SetActive(true);
            Crosshair.SetActive(false);
            Crosshair.GetComponent<Crosshair>().enabled = false;
            Debug.DrawRay(raycasting.ray.origin, raycasting.ray.direction*raycasting.maxDistanceRay, Color.green);
            if (Input.GetKeyDown(KeyCode.E))
            {
                raycasting.hit.transform.GetComponent<Door>().Open();
            }
        }
        else
        {
            DoorIcon.SetActive(false);
            Crosshair.SetActive(true);
            Crosshair.GetComponent<Crosshair>().enabled = true;
        }

    }


}
