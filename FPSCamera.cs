using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    //Toggles cursor visibility
    public bool VisibleCursor;

    //Controls camera's rotation sensititivy
    public Vector2 CameraSensitivity;

    //Keeps track of camera's current X & Y position.
    private Vector2 CamRotation;

    //Variable which gets control over the camera, used in Start()
    public Camera Cam;

    //Gets control over the camera
    //Toggles cursor's visibility
    private void Start()
    {
        Cam = Camera.main;
        Cursor.visible = VisibleCursor;
    }

    //Updates inputs
    private void Update()
    {
        CameraUpdate();
    }

    //Updates camera controls, used in Update()
    void CameraUpdate()
    {
        //Create variable for mouse X & Y inputs
        Vector2 CamController = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        //Adjust Player's X & Y rotation speed, with RotationSpeed
        CamController += CamController * CameraSensitivity;

        //TLDR: This will contain the camera's current X & Y rotation.
        //If not, it'll snap back to 0 on the X & Y axis.
        CamRotation.x -= CamController.y;
        CamRotation.y += CamController.x;

        //Makes sure we're locked at a 90 degree rotation (can't look up far enough to see behind you)
        Cam.transform.eulerAngles = new Vector3(Mathf.Clamp(CamRotation.x, -90, 90), CamRotation.y, 0f);

        //When player rotates mouse X input, rotate player.
        transform.Rotate(Vector3.up * CamController.x);
    }
}
