using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 100f;
    public float lightRange = 50f;
    float xRotation = 0f;

    public Transform body;
    public Transform lightTransform;

    public Light lightOBJ;

    //bool doLight = false;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        lightOBJ = lightTransform.GetComponent<Light>();
        lightOBJ.range = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (lightOBJ.range == lightRange)
                lightOBJ.range = 0f;
            else if (lightOBJ.range == 0f)
                lightOBJ.range = lightRange;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
        lightTransform.localRotation = transform.localRotation;
    }
}
