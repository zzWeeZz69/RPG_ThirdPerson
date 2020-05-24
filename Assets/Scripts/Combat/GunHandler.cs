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
        [SerializeField] Weapon CurrentWeapon = null;
        [SerializeField] Transform GunHolster = null;
        [SerializeField] Transform playerCamera = null;
        [SerializeField] LayerMask shootLayer = 0;
        public Action OnShoot;

        Controls controls;
        void Start()
        {
            controls = GetComponent<Controls>();
            OnShoot += FireShootRay;
            EqiupWeapon(CurrentWeapon);
        }

    
        void Update()
        {
            if (Input.GetKeyDown(controls.fire))
            {
                OnShoot?.Invoke();
            }
        }

        void FireShootRay()
        {
            // creates a ray from the camera
            Ray shootRay = new Ray(playerCamera.position, playerCamera.forward);
            RaycastHit hit = new RaycastHit();
            // shoots the ray
            Physics.Raycast(shootRay, out hit, 100, shootLayer);
            // gives the name of the object that you hit
            Debug.Log(hit.collider.gameObject.name);
        }

        private void EqiupWeapon(Weapon gun)
        {
            GameObject spawnedGun = Instantiate(gun.gunPrefab, GunHolster);
            spawnedGun.GetComponent<ShootHandler>().gunHandler = this;
        }
    }
}