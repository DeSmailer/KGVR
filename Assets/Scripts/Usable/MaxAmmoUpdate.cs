using System;
using UnityEngine;

public class MaxAmmoUpdate : MonoBehaviour, IUsable
{
    public int cost = 4;
    public int extraAmmo = 2;

    public Action OnCostChange;

    public void Use()
    {
        if (Stats.Instance.Money >= cost)
        {
            Stats.Instance.MaxAmmo += extraAmmo;
            Stats.Instance.Money -= cost;

            cost++;
            OnCostChange?.Invoke();
        }
    }
}