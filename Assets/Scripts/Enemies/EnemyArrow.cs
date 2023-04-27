using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private TrailRenderer trailRenderer;

    [SerializeField] private AudioSource _targetAudioSource;
    [SerializeField] private AudioSource _waterAudioSource;
    [SerializeField] private AudioSource _groundAudioSource;

    [SerializeField] private float _damage = 1;

    [SerializeField] private int _waterLayerMask;
    [SerializeField] private int _groundLayerMask;

    [SerializeField] private bool _isCollised = false;

    public void Shot(Transform ropeTransform, float velocity)
    {
        transform.parent = ropeTransform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        transform.parent = null;
        rb.isKinematic = false;
        rb.velocity = transform.forward * velocity;
        trailRenderer.Clear();
        trailRenderer.enabled = true;
        Destroy(gameObject, 15f);
    }

    private void GetStuck(StuckSounds stuckSounds)
    {
        if (stuckSounds == StuckSounds.Target)
        {
            Instantiate(_targetAudioSource, transform.position, Quaternion.identity);
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
        if (stuckSounds == StuckSounds.Water)
        {
            Instantiate(_waterAudioSource, transform.position, Quaternion.identity);
        }
        if (stuckSounds == StuckSounds.Ground)
        {
            if (!_isCollised)
            {
                Instantiate(_groundAudioSource, transform.position, Quaternion.identity);
            }
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == _groundLayerMask)
        {
            GetStuck(StuckSounds.Ground);
        }
        else
        {
            GetStuck(StuckSounds.Target);
        }

        _isCollised = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _waterLayerMask)
        {
            GetStuck(StuckSounds.Water);
            _isCollised = true;
        }

        ColonyHP colonyHP = other.gameObject.GetComponent<ColonyHP>();
        if (colonyHP != null)
        {
            colonyHP.TakeDamage(_damage);
        }
    }
}
