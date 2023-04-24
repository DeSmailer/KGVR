using System;
using UnityEngine;

public class ArrowSpeedUpdate : MonoBehaviour, IUsable
{
    public int cost = 4;
    public int extraSpeed = 2;

    public Action OnCostChange;

    public void Use()
    {
        if (Stats.Instance.Money >= cost)
        {
            Stats.Instance.ArrowSpeed += extraSpeed;
            Stats.Instance.Money -= cost;

            cost++;
            OnCostChange?.Invoke();
        }
    }
}
