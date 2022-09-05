using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    float x_Rotation;
    float y_Rotation;
    float y_RotationCurrent,x_RotationCurrent;
    Vector3 rotation;
    Vector3 orgrotation;
    public Camera player;
    public GameObject playerGameObject;
    public float sensitivity = 5f;
    public float smoothness = 0.1f;
    float currenttVelocityX,currenttVelocityY;
    void MouseMove()
    {
        x_Rotation += Input.GetAxis("Mouse X")*sensitivity*Time.deltaTime;
        y_Rotation += Input.GetAxis("Mouse Y")* sensitivity*Time.deltaTime;
        y_Rotation = Mathf.Clamp(y_Rotation, -90, 90);
        rotation = new Vector3(-y_Rotation, x_Rotation, 0f);

        
        x_RotationCurrent = Mathf.SmoothDamp(x_RotationCurrent, x_Rotation, ref currenttVelocityX, smoothness);
        y_RotationCurrent = Mathf.SmoothDamp(y_RotationCurrent, y_Rotation, ref currenttVelocityY, smoothness);
        
        player.transform.rotation = Quaternion.Euler(-y_RotationCurrent,x_RotationCurrent,0f);
        playerGameObject.transform.rotation = Quaternion.Euler(0f, x_RotationCurrent, 0f);
        
    }

    void Update()
    {
        MouseMove();
    }

}
