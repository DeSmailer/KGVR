using UnityEngine;

public class SpinnerBehindThePlayer : MonoBehaviour
{
    private Transform _player;

    private void Start()
    {
        _player = FindFirstObjectByType<PlayerMovement>().gameObject.transform;
    }

    void Update()
    {
        transform.LookAt(_player.position + new Vector3(0, 0, 360));
    }
}
