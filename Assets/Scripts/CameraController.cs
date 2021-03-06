using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Basic mouse components
    [Header("Camera Components")]
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    //Private variables
    float xRotation = 0f;

    //Components needed to zoom, values can be changed.
    [Header("Zoom Components")]
    public int zoom = 20;
    public int normal = 50;
    public float smooth = 5f;

    //Don't mess with this in the inspector (Hide in inspector)
    [HideInInspector]
    public bool isZoomed = false;

    // Start is called before the first frame update
    void Start()
    {
        //Hide cursor and lock it, so that it doesn't fly everywhere
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        CameraZoom();
    }
    private void CameraMovement()
    {
        //Grab inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Clamp the camera on the Y axis
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotate the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    private void CameraZoom()
    {
        //Once user presses button, turn true or false
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            isZoomed = !isZoomed;
        }
        //Zoom if pressed, unzoom if pressed again
        if (isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        }
        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
    }
}
