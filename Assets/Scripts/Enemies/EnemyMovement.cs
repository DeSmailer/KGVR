using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Zone _movementZone;
    private Vector3 target;

    [SerializeField] private float _speed;
    [SerializeField] private float _turningSpeed;

    [SerializeField] private EnemyHP _enemyHP;

    public void Initialize(Zone movementZone)
    {
        _movementZone = movementZone;
        _enemyHP = GetComponent<EnemyHP>();

        _enemyHP.OnDie += OnDie;

        SelectNewMovementPoint();
    }

    private void SelectNewMovementPoint()
    {
        target = _movementZone.GetRandomPoint();
    }

    private void Update()
    {
        if (target != null)
        {
            Move();
            LookAtTarget();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if (transform.position == target)
        {
            SelectNewMovementPoint();
        }
    }

    private void LookAtTarget()
    {
        Vector3 targetDir = target - transform.position;
        targetDir.y = 0;
        float step = _turningSpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void OnDie(EnemyHP enemyHP)
    {
        _speed = 0;
        _turningSpeed = 0;
        _enemyHP.OnDie -= OnDie;
    }
}
