using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private TrailRenderer trailRenderer;

    [SerializeField] private AudioSource _hitAudioSource;

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
        Destroy(gameObject, 15f);
    }

    private void GetStuck()
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;

        Instantiate(_hitAudioSource, transform.position, Quaternion.identity);
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player")
        {
            GetStuck();
        }

        if (other.transform.tag == "shootable")
        {
            GetStuck();
        }
    }
}