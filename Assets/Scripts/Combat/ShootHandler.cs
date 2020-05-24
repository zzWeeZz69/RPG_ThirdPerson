using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zlib;

namespace Zlib.Combat
{
    public class ShootHandler : MonoBehaviour
    {
        [SerializeField] Transform shootPoint = null;
        [SerializeField] float fireRate = 0f;
        [SerializeField] float damage = 10f;
        [SerializeField] float reloadSpeed = 3f;
        [Space]
        [SerializeField] float magSize = 12f;
        [SerializeField] int amauntOfMags = 3;
        [SerializeField] float adsTime = 0.5f;

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