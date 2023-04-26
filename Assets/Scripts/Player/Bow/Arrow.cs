using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private TrailRenderer trailRenderer;

    [SerializeField] private AudioSource _targetAudioSource;
    [SerializeField] private AudioSource _waterAudioSource;
    [SerializeField] private AudioSource _groundAudioSource;

    [SerializeField] private LayerMask _waterLayerMask;
    [SerializeField] private LayerMask _groundLayerMask;

    public void SetToRope(Transform ropeTransform, Transform bow)
    {
        transform.parent = ropeTransform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        rb.isKinematic = true;
        trailRenderer.enabled = false;
    }

    public void Shot(float velocity)
    {
        transform.parent = null;
        rb.isKinematic = false;
        rb.velocity = transform.forward * velocity;
        trailRenderer.Clear();
        trailRenderer.enabled = true;
        Destroy(gameObject, 5f);

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
            Destroy(gameObject, 0.1f);
        }
        if (stuckSounds == StuckSounds.Ground)
        {
            Instantiate(_groundAudioSource, transform.position, Quaternion.identity);
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }


    void OnCollisionEnter(Collision other)
    {
        EnemyHP enemyHP = other.gameObject.GetComponent<EnemyHP>();
        if (enemyHP != null)
        {
            enemyHP.TakeDamage(Stats.Instance.Damage);
        }

        if (other.gameObject.tag != "Player")
        {
            Debug.Log(other.gameObject.layer);
            if (other.gameObject.layer == _groundLayerMask)
            {
                GetStuck(StuckSounds.Ground);
            }
            else if (other.gameObject.layer == _waterLayerMask)
            {
                GetStuck(StuckSounds.Water);
            }
            else
            {
                GetStuck(StuckSounds.Target);
            }
        }
    }
}

public enum StuckSounds
{
    Target,
    Water,
    Ground
}