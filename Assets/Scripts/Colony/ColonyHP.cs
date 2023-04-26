using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColonyHP : MonoBehaviour
{
    public float maxHP;
    public float hp;

    public Action OnDie;
    public Action OnDamageTaken;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        hp = maxHP;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        OnDamageTaken?.Invoke();

        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnDie?.Invoke();
        Debug.Log($"Lose");

        Invoke("ReloadScene", 5);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
