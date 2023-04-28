using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private int _waveNumber = 0;
    [SerializeField] private float _firstDelay;
    [SerializeField] private float _delay;
    [SerializeField] private int _countInFirstWave;
    [SerializeField] private EnemyHP _enemyHPPrefab;

    [SerializeField] private Zone _spawnZone;
    [SerializeField] private Zone _movementZone;

    public List<EnemyHP> enemies = new List<EnemyHP>();

    public int WaveNumber
    {
        get
        {
            return _waveNumber;
        }
        set
        {
            _waveNumber = value;
            OnWaveNumberChange?.Invoke();
        }
    }

    public Action OnWaveNumberChange;
    public Action<int, float> OnNewWaveThrough;

    private void Start()
    {
        Invoke("StartNewWave", _firstDelay);
        OnNewWaveThrough?.Invoke(_waveNumber + 1, _firstDelay);
    }

    public void StartNewWave()
    {
        _waveNumber++;
        int count = _countInFirstWave + (int)(WaveNumber * 1.5f);
        for (int i = 0; i < count; i++)
        {
            EnemyHP enemyHP = SpawnEnemy();
            enemyHP.OnDie += OnenemyDie;
            enemies.Add(enemyHP);
        }
    }

    private void OnenemyDie(EnemyHP enemyHP)
    {
        enemyHP.OnDie -= OnenemyDie;
        enemies.Remove(enemyHP);

        if (enemies.Count <= 0)
        {
            Invoke("StartNewWave", _delay);
            OnNewWaveThrough?.Invoke(_waveNumber + 1, _delay);
        }
    }

    private EnemyHP SpawnEnemy()
    {
        EnemyHP enemyHP = Instantiate(_enemyHPPrefab, _spawnZone.GetRandomPoint(), Quaternion.identity);
        EnemyMovement enemyMovement = enemyHP.GetComponent<EnemyMovement>();

        enemyHP.Initialize(1);
        enemyMovement.Initialize(_movementZone);

        return enemyHP;
    }
}
