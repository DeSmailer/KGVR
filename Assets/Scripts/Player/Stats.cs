using System;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int _maxAmmo;
    private int _ammo;
    [SerializeField] private float _firingRange;
    [SerializeField] private float _damage;
    private int _money;

    public static Stats Instance;

    public Action OnMaxAmmoChange;
    public Action OnAmmoChange;
    public Action OnFiringRangeChange;
    public Action OnDamageChange;
    public Action OnMoneyChange;

    public int MaxAmmo
    {
        get { return _maxAmmo; }
        set
        {
            _maxAmmo = value;
            OnMaxAmmoChange?.Invoke();
        }
    }

    public int Ammo
    {
        get { return _ammo; }
        set
        {
            _ammo = value;
            OnAmmoChange?.Invoke();
        }
    }

    public float FiringRange
    {
        get { return _firingRange; }
        set
        {
            _firingRange = value;
            OnFiringRangeChange?.Invoke();
        }
    }

    public float Damage
    {
        get { return _damage; }
        set
        {
            _damage = value;
            OnDamageChange?.Invoke();
        }
    }
    
    public int Money
    {
        get { return _money; }
        set
        {
            _money = value;
            OnMoneyChange?.Invoke();
        }
    }

    //υο ρελΰ

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        Ammo = MaxAmmo;
    }
}
