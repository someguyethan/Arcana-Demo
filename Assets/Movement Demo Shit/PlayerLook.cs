using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] WallRun wallRun;

    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] Transform cam;
    [SerializeField] Transform orientation;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRot;
    float yRot;

    public float TouchSensitivity_x = 10f;
    public float TouchSensitivity_y = 10f;

    public GameObject body;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        Application.targetFrameRate = 60;
    }
    private void Update()
    {
        MyInput();

        cam.transform.localRotation = Quaternion.Euler(xRot, yRot, wallRun.tilt);
        orientation.transform.rotation = Quaternion.Euler(0, yRot, 0);
        body.transform.rotation = Quaternion.Euler(0, yRot, 0);
    }
    void MyInput()
    {
        mouseX = HandleAxisInputDelegate("Mouse X");
        mouseY = HandleAxisInputDelegate("Mouse Y");

        yRot += mouseX * sensX * multiplier;
        xRot -= mouseY * sensY * multiplier;

        xRot = Mathf.Clamp(xRot, -90f, 90f);
    }
    float HandleAxisInputDelegate(string axisName)
    {
            switch (axisName)
            {

                case "Mouse X":

                    if (Input.touchCount > 0 && Input.touches[0].position.x > Screen.width / 4)
                    {
                        return Input.touches[0].deltaPosition.x / TouchSensitivity_x;
                    }
                    else
                    {
                        return Input.GetAxis(axisName);
                    }

                case "Mouse Y":
                    if (Input.touchCount > 0 && Input.touches[0].position.x > Screen.width / 4)
                    {
                        return Input.touches[0].deltaPosition.y / TouchSensitivity_y;
                    }
                    else
                    {
                        return Input.GetAxis(axisName);
                    }

                default:
                    Debug.LogError("Input <" + axisName + "> not recognyzed.", this);
                    break;
            }

        return 0f;
    }
}
