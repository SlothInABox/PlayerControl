using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Which player is using the script
    public string inputID;

    // Camera attributes
    public Camera firstPersonCamera;
    public Camera overheadCamera;
    public KeyCode switchKey;

    // Speed variable
    [SerializeField] private float speed = 20.0f;
    // Turnspeed
    [SerializeField] private float turnSpeed = 45.0f;

    // Movement inputs
    public float horizontalInput;
    public float forwardInput;

    private void SwitchView()
    {
        // Toggle cameras
        firstPersonCamera.enabled = !firstPersonCamera.enabled;
        overheadCamera.enabled = !overheadCamera.enabled;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        // Move the vehicle forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Turn vehicle based on horiztonal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        // Detect camera switch
        if (Input.GetKeyDown(switchKey))
        {
            SwitchView();
        }
    }
}
