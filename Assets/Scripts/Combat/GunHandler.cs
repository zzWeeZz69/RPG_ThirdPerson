using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zlib;
using Zlib.Core;

namespace Zlib.Combat
{
    public class GunHandler : MonoBehaviour
    {
        [SerializeField] GameObject gun = null;
        [SerializeField] Transform GunHolster = null;

        public Action Shoot;

        Controls controls;
        void Start()
        {
            controls = GetComponent<Controls>();
            EqiupWeapon(gun);
        }

    
        void Update()
        {
            if (Input.GetKeyDown(controls.fire))
            {
                Shoot?.Invoke();
            }
        }

        private void EqiupWeapon(GameObject gun)
        {
            Instantiate(gun, GunHolster);
            gun.GetComponent<ShootHandler>().gunHandler = this;
        }
    }
}