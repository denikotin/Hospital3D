using UnityEngine;

public class Crosshair : MonoBehaviour
{
    
    RectTransform crosshair;
    [SerializeField] float sizeState;
    [SerializeField] float moveSize;
    [SerializeField] float currentSize;
    [SerializeField] float smoothness;
    float size,currentVelocity;

    [SerializeField] PlayerMove player;


    void Start(){
        crosshair = GetComponent<RectTransform>();
    }
    void Update()
    {
        if (isMoving)
        {
            currentSize = moveSize;
            if (player.speed > 7)
            {
                currentSize = moveSize + 50f;
            }
        }
        else
        {
            currentSize = sizeState;
        }

        size = Mathf.SmoothDamp(size, currentSize, ref currentVelocity, smoothness);
        crosshair.sizeDelta = new Vector2(size,size);
    }
    bool isMoving
    {
        get
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") !=0)
            {
                return true;
            }
            else 
            {
                return false;
            }

        }
    }

}
