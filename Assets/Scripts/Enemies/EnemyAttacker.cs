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

    [SerializeField] [Range(0, 100)] private float _random = 50;

    private float Delay => Random.Range(_minDelay, _maxDelay);

    private void Start()
    {
        Invoke("Shoot", Delay);
    }

    private void Shoot()
    {
        foreach (Guides guide in _guides)
        {
            float random = Random.Range(0, 100);
            if (random <= _random)
            {
                guide.Shot();
            }
        }
        Invoke("Shoot", Delay);
    }
}
