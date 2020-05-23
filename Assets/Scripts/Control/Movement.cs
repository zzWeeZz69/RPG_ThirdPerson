using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zlib;
using Zlib.Core;

namespace Zlib.Control
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] LayerMask groundlayer = 0;
        [SerializeField] float movementSpeed = 1f;
        [SerializeField] float sprintMultiPlyer = 1.5f;
        float currspeed => CurrentSpeed();
        private CharacterController controller;
        private Controls controls;
        [HideInInspector] public float _movementSpeed => movementSpeed;
        [HideInInspector] public float _sprintMultiPlyer => sprintMultiPlyer;

        Vector3 velocity;
        void Start()
        {
            controller = GetComponent<CharacterController>();
            controls = GetComponent<Controls>();
        }


        void Update()
        {
            // move the player
            Locomotion();
            // gives the player gravity
            Gravity();
        }

        private void Locomotion()
        {

            // creates a vector3 with the calculated movement in local space
            Vector3 move = transform.right * controls.GetInputVector().x + transform.forward * controls.GetInputVector().z * SmoothSprintMultiplyer();

            // adds movement to the character controller whitch gets multiplyed with the movement speed
            controller.Move(move * CurrentSpeed() * Time.deltaTime);
        }

        float lerpValue;
        private float SmoothSprintMultiplyer()
        {
            // forces the lerp value to stay between 0 and 1
            lerpValue = Mathf.Clamp01(lerpValue);
            

            // increases the lerp value if sprint key is down
            if (Input.GetKey(controls.Sprint)) lerpValue += Time.deltaTime * 3;
            // resets the lerp Value
            else lerpValue -= Time.deltaTime * 3;

            // smooths the sprint multiplyer
            return Mathf.Lerp(1, sprintMultiPlyer, lerpValue);
            
        }

        float speedLerp;
        private float CurrentSpeed()
        {

            speedLerp = Mathf.Clamp01(speedLerp);
            // if the input vector has a increasing value than the speed lerp will go to 1 in 1/10 of a second
            if (controls.GetInputVector().magnitude > 0) speedLerp += Time.deltaTime * 3;
            // resets the speed lerp at the same speed
            else speedLerp = 0;

            if (!IsGrounded())
                return Mathf.Lerp(0, movementSpeed / 4, speedLerp);

            // sets current speed to the desiredSpeed
            return Mathf.Lerp(0, movementSpeed, speedLerp);
        }


        private void Gravity()
        {
            // resets the gravity velocity when grounded
            if (IsGrounded() && velocity.y < 0) velocity.y = -2f;

            // calculates the gravity
            velocity.y += Physics.gravity.y * Time.deltaTime;

            // adds the gravity to the player
            controller.Move(velocity * Time.deltaTime);
        }

        private bool IsGrounded()
        {
            // creates the ray
            Ray groundedRay = new Ray(transform.position, Vector3.down);
            
            // check if the ray is tutsing the ground and returns true
            return Physics.Raycast(groundedRay, 1.5832f, groundlayer);
        }
    }
}