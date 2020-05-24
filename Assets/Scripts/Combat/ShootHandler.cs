using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zlib;

namespace Zlib.Combat
{
    public class ShootHandler : MonoBehaviour
    {
        [SerializeField] Transform shootPoint = null;
        

        [HideInInspector] public GunHandler gunHandler;
        void Start()
        {
            gunHandler.OnShoot += Shoot;
        }

        void Shoot()
        {
            
            
        }
    }
}