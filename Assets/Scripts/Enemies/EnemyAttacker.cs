using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Guides[] _guides;
    [SerializeField] private float _delay = 1;

    private void Start()
    {
        Invoke("Shoot", _delay);
    }

    private void Shoot()
    {
        foreach (Guides guide in _guides)
        {
            guide.Shot();
        }
        Invoke("Shoot", _delay);
    }
}
