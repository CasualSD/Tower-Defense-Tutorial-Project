using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamController : MonoBehaviour
{
    private bool DoMovement = true;

    public float MouseSens = 1000f;
    public Transform PlayerBody;
    float xRotation = 0f;
    public float speed = 30f;
    public float MinY = 5f;
    public float MaxY = 150f;
    public float MinZ = -8f;
    public float MaxZ = 80f;
    public float MinX = -150f;
    public float MaxX = 20f;
    public float PanSpeed = 60f;
    public CharacterController controller;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DoMovement = !DoMovement;
        }
        if (DoMovement == false)
        {
            return;
        }

        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            PlayerBody.Rotate(Vector3.up * mouseX);
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(move * speed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, MinY, MaxY);
        pos.z = Mathf.Clamp(pos.z, MinZ, MaxZ);
        pos.x = Mathf.Clamp(pos.x, MinX, MaxX);
        transform.position = pos;
    }
}
