using System;
using UnityEngine;

public class DamageUpdate : MonoBehaviour, IUsable
{
    public int cost = 4;
    public int extraDamage = 1;

    public Action OnCostChange;

    public void Use()
    {
        if (Stats.Instance.Money >= cost)
        {
            Stats.Instance.Damage += extraDamage;
            Stats.Instance.Money -= cost;

            cost++;
            OnCostChange?.Invoke();
        }
    }
}
