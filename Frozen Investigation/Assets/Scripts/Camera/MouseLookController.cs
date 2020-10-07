using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookController : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
     private float mouseSensivity = 300f;

    

    private MouseModel mouseModel;
    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//Cannot move the camera up than 90 degre

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //The way to rotate in unity
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
