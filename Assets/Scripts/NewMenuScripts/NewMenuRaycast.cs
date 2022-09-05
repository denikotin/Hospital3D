using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMenuRaycast : MonoBehaviour
{
    public Camera fpcCamera;
    public Ray ray;
    public RaycastHit hit;    
    public float maxDistanceRay;


    void Update()
    {
        Ray();
        DrawRay();
    }
    private void Ray()
    {
        ray = fpcCamera.ScreenPointToRay(Input.mousePosition);
    }

    private void DrawRay()
    {
        if(Physics.Raycast(ray, out hit, maxDistanceRay))
        {
            Debug.DrawRay(ray.origin, ray.direction* maxDistanceRay, Color.blue);
        }
        
        if(hit.transform == null)
        {
            Debug.DrawRay(ray.origin, ray.direction*maxDistanceRay, Color.red);
        }
    }
}
