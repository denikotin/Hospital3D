using UnityEngine;
using UnityEngine.UI;
public class Building : MonoBehaviour
{
    [SerializeField] private Transform parent;
    public Raycasting raycasting;
    public Outlining outlining;
    
    private Outline outline;
    private Transform createdObject;
    
    private float mouseScroll = 0;


    public void StartInstantiate(Transform prefab)
    {
        createdObject = Instantiate(prefab, raycasting.hit.point, Quaternion.identity);
        createdObject.SetParent(parent);
        if (createdObject.GetComponent<BoxCollider>())
        {
            createdObject.GetComponent<BoxCollider>().enabled = false;
        }
    }


    void Update()
    {
        MoveInstantiatedObject();
        OutlineObject();
    }

    private void MoveInstantiatedObject()
    {
        if (createdObject != null)
        {
            createdObject.transform.position = raycasting.hit.point;
            mouseScroll += Input.GetAxis("Mouse ScrollWheel")*20;
            createdObject.transform.rotation = Quaternion.Euler(0, mouseScroll, 0);
            if (Input.GetMouseButtonDown(0))
            {
                if(createdObject.GetComponent<BoxCollider>())
                {
                    createdObject.GetComponent<BoxCollider>().enabled = true;
                    createdObject = null;
                }
                if (createdObject.GetComponent<MeshCollider>())
                {
                    createdObject.GetComponent<MeshCollider>().enabled = true;
                    createdObject = null;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(createdObject.gameObject);
            }
        }
        else
        {
            if (raycasting.hit.collider)
            {
                if (raycasting.hit.collider.gameObject.layer == 7)
                {
                    float createdObjectRotationX = raycasting.hit.transform.rotation.x;
                    float createdObjectRotationY = raycasting.hit.transform.rotation.y;
                    float createdObjectRotationZ = raycasting.hit.transform.rotation.z;
                    Debug.Log(createdObjectRotationX+" "+createdObjectRotationY+" "+createdObjectRotationZ);
                    if (Input.GetMouseButtonDown(0))
                    {
                        createdObject = raycasting.hit.transform;
                        if (createdObject.GetComponent<BoxCollider>())
                        {
                            createdObject.GetComponent<BoxCollider>().enabled = false;
                        }
                        if (createdObject.GetComponent<MeshCollider>())
                        {
                            createdObject.GetComponent<MeshCollider>().enabled = false;
                        }
                    }
                }
            }
            
        }

    }

    private void OutlineObject()
    {
        if (raycasting.hit.collider)
        {
            outline = raycasting.hit.collider.GetComponent<Outline>();
            outlining.Outline(outline);
        }
    }
}
