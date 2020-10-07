using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private float speed = 10f;
    private float gravity = -9.81f;
    private Vector3 velocity;
    public float groundDistance = 0.1f;
    private float jumpForce = 2f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheck;
    private bool isGrounded;
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded)
        {
            Debug.Log("geround");

            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("jumping");
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);

            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
        //creating gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

    }
}