using UnityEngine;

public class EnemieHP : MonoBehaviour
{
    [SerializeField] private float _maxHP;
    [SerializeField] private float _hp;

    private void Start()
    {
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
        Debug.Log($"ÀÌÀ ÄÀÉ {gameObject.name}");
    }
}
