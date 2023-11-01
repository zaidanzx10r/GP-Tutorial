using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : WeaponBase
{
    protected override void Attack(float percent)
    {
        print("My weapon attacked" + percent);
    }

}
