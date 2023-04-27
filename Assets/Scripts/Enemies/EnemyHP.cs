using System;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private float _maxHP;
    [SerializeField] private float _hp;

    public Action<EnemyHP> OnDie;

    private bool _isAlive = true;

    private void Start()
    {
        Invoke("Die", UnityEngine.Random.Range(0.1f, 1f));
    }

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
        if (_isAlive)
        {
            _hp -= damage;

            if (_hp <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        _isAlive = false;

        Stats.Instance.Money += (int)(2 + _maxHP / 2);

        Debug.Log($"ÀÌÀ ÄÀÉ {gameObject.name}");

        OnDie?.Invoke(this);
    }
}
