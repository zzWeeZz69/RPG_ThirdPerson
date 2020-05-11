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
        public KeyCode forwards, backwards, strafeLeft, strafeRight, interact;

        public Action OnInteractClick;
        public Action OnInteractHold;

        bool PassedThreshold;
        float holdThreshold = 0.2f;
        float currentThreshold;
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

            if(Input.GetKeyUp(interact))
                currentThreshold = 0;
        }
    }
}