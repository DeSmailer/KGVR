using System;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private float _maxHP;
    [SerializeField] private float _hp;

    public Action<EnemyHP> OnDie;

    public void Initialize()
    {
        _hp = _maxHP;
    }

    public void Initialize(float maxHP)
    {
        _maxHP = maxHP;
        _hp = _maxHP;
    }

    public void TakeDamage(float damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Stats.Instance.Money += (int)(2+_maxHP / 2);
        OnDie?.Invoke(this);
        Debug.Log($"ÀÌÀ ÄÀÉ {gameObject.name}");
    }
}
