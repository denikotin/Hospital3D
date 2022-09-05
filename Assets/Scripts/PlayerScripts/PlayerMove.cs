using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    CharacterController player;
    public float speed;
    private float x_Move,z_Move;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float sprintSpeed = 50f;
    [SerializeField] float jumpForce,gravity;
    private Vector3 move_directional;
    

    private void Start()
    {
        player = GetComponent<CharacterController>();
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        x_Move = Input.GetAxis("Horizontal");
        z_Move = Input.GetAxis("Vertical");

        if (player.isGrounded)
        {
            move_directional = new Vector3(x_Move, 0f, z_Move);
            move_directional = transform.TransformDirection(move_directional);

            if (Input.GetKey(KeyCode.Space))
            {
                move_directional.y += jumpForce;
            };
        }
        else 
        {
            move_directional.y -= gravity;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = moveSpeed;
        };

        player.Move(move_directional*Time.deltaTime*speed);

    }
}
