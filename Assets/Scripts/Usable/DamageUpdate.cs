using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpdate : MonoBehaviour, IUsable
{
    public void Use()
    {
        Stats.Instance.Ammo = Stats.Instance.MaxAmmo;
    }
}
    