using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zlib;

namespace Zlib.Combat
{
    public class ShootHandler : MonoBehaviour
    {
        [SerializeField] float fireRate;
        [SerializeField] float damage;
        [SerializeField] float reloadSpeed;
        [Space]
        [SerializeField] float magSize;
        [SerializeField] int amauntOfMags;
        [SerializeField] float adsTime;

        [HideInInspector] public GunHandler gunHandler;
        void Start()
        {
            gunHandler.Shoot += Shoot;
        }

        void Shoot()
        {
            Debug.Log("*Shoot*");
        }
    }
}