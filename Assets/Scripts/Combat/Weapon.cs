using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zlib;

namespace Zlib.Combat
{
    public enum WeaponType
    {
        Single_Fire,
        Full_Auto,
        Burst
    }

    [CreateAssetMenu(fileName = "new Weapon", menuName = "Weapon")]
    public class Weapon : ScriptableObject
    {
        public string Name;
        public WeaponType weaponType;
        public GameObject gunPrefab;
        public AnimatorOverrideController gunAnimationOverride;
        [Space]
        [Header("Stats")]
        [Tooltip("How many round shot in a second.")]
        public float fireRate = 0f;
        public float damage = 10f;
        public float reloadSpeed = 3f;
        [Space]
        public float magSize = 12f;
        public int amauntOfMags = 3;
        public float adsTime = 0.5f;
    }
}