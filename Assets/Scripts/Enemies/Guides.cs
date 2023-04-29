using UnityEngine;

public class Guides : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float _arrowSpeed;
    public GameObject ar;

    private void Start()
    {
        ColonyHP colonyHP = FindFirstObjectByType<ColonyHP>();
        _target = colonyHP.GetTarget();
    }

    void Update()
    {
        transform.LookAt(_target);
    }

    public void Shot()
    {
        if (Vector3.Distance(transform.position, _target.position) <= 160f)
        {
            EnemyArrow CurrentArrow = Instantiate(ar).GetComponent<EnemyArrow>();

            CurrentArrow.Shot(transform, _arrowSpeed);
        }

    }
}
