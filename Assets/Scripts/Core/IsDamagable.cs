using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zlib;

namespace Zlib.Core
{
    public abstract class IsDamagable
    {
        public float hitPoints, maxHitPoints;

        public event Action OnHit;

        public bool IsDead
        {           
            get
            {
                return hitPoints < 0;
            }
        }


        public void doDamage(float damage)
        {
            hitPoints = Mathf.Max(hitPoints - damage, 0);
            OnHit();
        }
    }
}