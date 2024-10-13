using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private CharacterController controller;
    // movement on x / z
    public float speed = 10f;
    private float x, z;

    // movement on y 
    private Vector3 velocity;
    private float gravity = 9.81f;

    private float jumpHeight = 2f;
    public LayerMask groundMask;
    public Transform groundcheck;
    private bool isGround;
    private float radiusOfCheck = 0.5f;

    void Start()
    {
        // init controler
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        isGround = Physics.CheckSphere(groundcheck.position, radiusOfCheck, groundMask);

        if (isGround && velocity.y < 0f)
        {
            velocity.y = -1f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }
        // get coords
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 moveplayer = transform.right * x + transform.forward * z;
        // move player on x/z 
        controller.Move(moveplayer * speed * Time.deltaTime);


        // move player on y 
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
