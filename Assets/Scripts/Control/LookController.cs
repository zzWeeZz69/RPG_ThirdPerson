using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zlib;
using Zlib.Core;

namespace Zlib.Control
{
    public class LookController : MonoBehaviour
    {
        [SerializeField] Transform playerCamera;
        [SerializeField] Vector2 verticalClampValue;
        Controls controls;

        float xRotation = 0f;
        void Start()
        {
            controls = GetComponent<Controls>();
            Cursor.lockState = CursorLockMode.Locked;
        }
    
        void Update()
        {
            // Funktion that handels the aiming of the player
            CameraLook();
        }

        private void CameraLook()
        {
            // gets the input values and multiply it with the sensetivity value
            float mouseX = Input.GetAxis("Mouse X") * controls.sensetivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * controls.sensetivity * Time.deltaTime;

            // inverts so the Y movement is correct
            xRotation -= mouseY;
            // Clamps the value of the Y value so you dont continue spinning when you look up or down
            xRotation = Mathf.Clamp(xRotation, verticalClampValue.x, verticalClampValue.y);

            // adds the rotation to the player
            transform.Rotate(Vector3.up * mouseX);
            // adds the rotation to the camera
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }
}