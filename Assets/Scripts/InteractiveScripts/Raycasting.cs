using UnityEngine;

public class Raycasting : MonoBehaviour
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
        ray = fpcCamera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
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
