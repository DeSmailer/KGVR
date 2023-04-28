using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDeathController : MonoBehaviour
{
    [SerializeField] private EnemyHP _enemyHP;

    [SerializeField] [Range(-40, 0)] private float _rotationMinX = -40;
    //[SerializeField] [Range(-40, 0)] private float _rotationMinY = -40;
    [SerializeField] [Range(-40, 0)] private float _rotationMinZ = -40;

    [SerializeField] [Range(0, 40)] private float _rotationMaxX = 40;
    //[SerializeField] [Range(0, 40)] private float _rotationMaxY = 40;
    [SerializeField] [Range(0, 40)] private float _rotationMaxZ = 40;

    [SerializeField] [Range(0, 10)] private float _smooth;
    [SerializeField] [Range(0, 1)] private float _tiltsTime = 0.4f;
    [SerializeField] [Range(0, 3)] private float _drowningTime = 1;
    [SerializeField] private float _drowningSpeed = 1;

    private float rotationX => Random.Range(_rotationMinX, _rotationMaxX);
    //private float rotationY => Random.Range(_rotationMinY, _rotationMaxY);
    private float rotationZ => Random.Range(_rotationMinZ, _rotationMaxZ);

    [SerializeField] private float _rotationX;
    //[SerializeField] private float _rotationY;
    [SerializeField] private float _rotationZ;

    private void Start()
    {
        _enemyHP = GetComponent<EnemyHP>();
        _enemyHP.OnDie += OnDie;
    }

    private IEnumerator TiltsToSide()
    {
        _rotationX = rotationX;
        _rotationZ = rotationZ;

        Vector3 rotation = new Vector3(_rotationX, 0, _rotationZ) * _smooth * Time.deltaTime;
        Debug.Log(rotation);

        while (_tiltsTime > 0)
        {
            _tiltsTime -= Time.deltaTime;

            transform.Rotate(rotation);

            yield return null;
        }
    }

    private IEnumerator Drown()
    {
        Vector3 step = new Vector3(0, _drowningSpeed, 0);

        while (_drowningTime > 0)
        {
            _drowningTime -= Time.deltaTime;

            transform.position -= step * Time.deltaTime;

            yield return null;
        }
    }

    private void OnDie(EnemyHP enemyHP)
    {
        _rotationX = rotationX;
        _rotationZ = rotationZ;

        StartCoroutine(TiltsToSide());
        StartCoroutine(Drown());
        _enemyHP.OnDie -= OnDie;
    }
}
