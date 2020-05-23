using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zlib;

namespace Zlib.Core
{
    [System.Serializable]
    public class Controls : MonoBehaviour
    {
        public KeyCode forwards, backwards, strafeLeft, strafeRight, interact, Sprint, fire, aim;
        [Range(10, 1000)] public float sensetivity = 55f;

        public Action OnInteractClick;
        public Action OnInteractHold;

        bool PassedThreshold;
        float holdThreshold = 0.2f;
        float currentThreshold;

        protected static Controls controls;

        private void Awake()
        {
            controls = this;
        }

        private void Update()
        {
            // controls what interaction type it is           
            ControlInteraction();
        }

        bool Interacting = false;
        private void ControlInteraction()
        {

            // starts the Interact contol
            if (Input.GetKeyDown(interact))
                Interacting = true;
            if (Input.GetKey(interact) && Interacting)
            {
                currentThreshold += Time.deltaTime;
            }
            // Checks if Current threshold has passed the dead time for click
            PassedThreshold = currentThreshold > holdThreshold ? true : false;
            // fires click event
            if (Input.GetKeyUp(interact) && !PassedThreshold)
            {
                OnInteractClick?.Invoke();
                Debug.Log("Click");
                Interacting = false;

            }

            // when the current threshold have passed 1 sec the controller detects the hold and fires the onInteractHold event
            if (currentThreshold >= 1)
            {
                OnInteractHold?.Invoke();
                Debug.Log("HoldInteract");
                currentThreshold = 0;
                Interacting = false;
                return;
            }

            if (Input.GetKeyUp(interact))
                currentThreshold = 0;
        }

        // converts the movement inputs to a vector3
        public Vector3 GetInputVector()
        {
            float x = 0f;
            float z = 0f;
            if (Input.GetKey(forwards)) z = 1;
            if (Input.GetKey(backwards)) z = -1;
            if (Input.GetKey(backwards) && Input.GetKey(forwards)) z = 0;
            if (Input.GetKey(strafeRight)) x = 1;
            if (Input.GetKey(strafeLeft)) x = -1;
            if (Input.GetKey(strafeLeft) && Input.GetKey(strafeRight)) x = 0;

            return new Vector3(x, 0, z);
        }
    }
}