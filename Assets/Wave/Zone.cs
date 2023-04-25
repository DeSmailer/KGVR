using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private Transform _leftUp;
    [SerializeField] private Transform _rightDown;

    public Vector3 GetRandomPoint()
    {
        float randomX = Random.Range(_leftUp.position.x, _rightDown.position.x);
        float randomZ = Random.Range(_rightDown.position.z, _leftUp.position.z);

        return new Vector3(randomX, 0, randomZ);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(_leftUp.position, new Vector3(_rightDown.position.x, _rightDown.position.y, _leftUp.position.z));
        Gizmos.DrawLine(_leftUp.position, new Vector3(_leftUp.position.x, _rightDown.position.y, _rightDown.position.z));

        Gizmos.DrawLine(_rightDown.position, new Vector3(_leftUp.position.x, _leftUp.position.y, _rightDown.position.z));
        Gizmos.DrawLine(_rightDown.position, new Vector3(_rightDown.position.x, _leftUp.position.y, _leftUp.position.z));
    }
}
