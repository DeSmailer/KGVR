using UnityEngine;

public class MovementInTheGazeDirection : MonoBehaviour
{
    [SerializeField] private Transform _rayStart;
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private bool _isHit = false;

    [SerializeField] private RaycastHit _hit;

    [SerializeField] private Transform _sphere;

    void FixedUpdate()
    {
        _sphere.gameObject.SetActive(false);

        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(_rayStart.position, _rayStart.TransformDirection(Vector3.forward), out _hit, _distance, _mask))
            {
                Debug.DrawRay(_rayStart.position, _rayStart.TransformDirection(Vector3.forward) * _hit.distance, Color.yellow);

                _sphere.position = _hit.point;
                _sphere.gameObject.SetActive(true);

                _isHit = true;

                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(_rayStart.position, _rayStart.TransformDirection(Vector3.forward) * 1000, Color.white);

                _sphere.gameObject.SetActive(false);

                _isHit = false;

                Debug.Log("Did not Hit");
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (_isHit)
            {
                Teleport();
            }
        }
    }

    private void Teleport()
    {
        transform.position = _hit.point + new Vector3(0, 1, 0);
    }
}