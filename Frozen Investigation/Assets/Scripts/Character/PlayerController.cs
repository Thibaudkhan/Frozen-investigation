using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private float speed = 10f;
    private float gravity = -9.81f;
    private Vector3 velocity;
    public float groundDistance = 0.1f;
    private float jumpForce = 1f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheck;
    private bool isGrounded;
    private IdentificationController identification;
    private Transform iden;
    //protected bool isInteracting = false;
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        iden = transform.Find("Detection");
        identification = iden.GetComponent<IdentificationController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);




        if (isGrounded)
        {
            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);

            }
            //run 
            if (Input.GetKey(KeyCode.Z))
            {
                Run();
            }
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // creating movement
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
        //creating gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

    }

    private float Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20f;
            Debug.Log("running : " + speed);
        }
        else
        {
            speed = 10f;
            Debug.Log(speed);
        }
        return speed;
    }

}