using UnityEngine;

public class AmmoChest : MonoBehaviour, IUsable
{
    public void Use()
    {
        Stats.Instance.Ammo = Stats.Instance.MaxAmmo;
    }
}
