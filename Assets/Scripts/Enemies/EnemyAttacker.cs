using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    ////пулемет

    //[SerializeField] private Guides[] _guides;
    //[SerializeField] private float _delay = 1;

    //private void Start()
    //{
    //    Invoke("Shoot", _delay);
    //}

    //private void Shoot() 
    //{
    //    foreach (Guides guide in _guides)
    //    {
    //        guide.Shot();
    //    }
    //    Invoke("Shoot", _delay);
    //}

    ////пулемет

    [SerializeField] private Guides[] _guides;

    [SerializeField] private float _minDelay = 1;
    [SerializeField] private float _maxDelay = 3;

    [SerializeField] [Range(0, 100)] private float _chanceToShoot = 50;

    [SerializeField] private EnemyHP _enemyHP;
    [SerializeField] private bool _isDead = false;

    private float Delay => Random.Range(_minDelay, _maxDelay);

    private void Start()
    {
        _enemyHP = GetComponent<EnemyHP>();
        _enemyHP.OnDie += OnDie;

        Invoke("Shoot", Delay);
    }

    private void Shoot()
    {
        if (_isDead)
            return;

        foreach (Guides guide in _guides)
        {
            float random = Random.Range(0, 100);
            if (random <= _chanceToShoot)
            {
                guide.Shot();
            }
        }
        Invoke("Shoot", Delay);
    }

    private void OnDie(EnemyHP enemyHP)
    {
        _isDead = true;
        _enemyHP.OnDie -= OnDie;
    }
}
