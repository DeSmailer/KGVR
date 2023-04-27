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

    [SerializeField] private float _smooth;

    private float rotationX => Random.Range(_rotationMinX, _rotationMaxX);
    //private float rotationY => Random.Range(_rotationMinY, _rotationMaxY);
    private float rotationZ => Random.Range(_rotationMinZ, _rotationMaxZ);

    [SerializeField] private float _rotationX;
    [SerializeField] private float _rotationY;
    [SerializeField] private float _rotationZ;

    private void Start()
    {
        _enemyHP = GetComponent<EnemyHP>();
        _enemyHP.OnDie += OnDie;
    }

    private IEnumerator Die()
    {
        Quaternion target = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationZ);

        while (true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
            yield return null;
        }


        //Vector3 vector3 = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z) + new Vector3(_rotationX, 0, _rotationZ);
        ////кватернион не 360 а 0-1
        //Debug.Log("transform.rotation = " + transform.rotation);
        //Debug.Log("transform.rotation.y = " + transform.rotation.y);
        //Debug.Log("vector3.y = " + vector3.y);
        //float y = transform.rotation.y;
        //Quaternion target = Quaternion.Euler(vector3.x, y, vector3.z);
        //Debug.Log("target.y = " + target.y);

        //while (true)
        //{
        //    Debug.Log("transform.rotation = " + transform.rotation);
        //    Debug.Log("transform.rotation.y = " + transform.rotation.y);
        //    Debug.Log("vector3.y = " + vector3.y);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
        //    yield return null;
        //}

        ////////////////////////////////////////////////////////

        //  Quaternion target = Quaternion.Euler(rotationX, transform.rotation.y, rotationZ);
        //for (; transform.rotation.x != _rotationX && transform.rotation.z != _rotationZ;)
        //{
        //Quaternion newRotation = transform.rotation;
        //if (transform.rotation.x < _rotationX)
        //{
        //    newRotation.x += _smooth;
        //}
        //Debug.Log("+");
        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
        //}


    }

    private void OnDie(EnemyHP enemyHP)
    {
        _rotationX = rotationX;
        _rotationZ = rotationZ;

        StartCoroutine(Die());
        _enemyHP.OnDie -= OnDie;
    }
}
