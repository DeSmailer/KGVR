using UnityEngine;

public class Guides : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float _arrowSpeed;

    private void Start()
    {
        ColonyHP colonyHP = FindFirstObjectByType<ColonyHP>();
        _target = colonyHP.GetTarget();
    }

    void Update()
    {
        transform.LookAt(_target);
    }

    private AudioSource ArrowAudio;

    public GameObject ar;

    public void Shot()
    {
        EnemyArrow CurrentArrow = Instantiate(ar).GetComponent<EnemyArrow>();

        CurrentArrow.SetToRope(transform, transform);
        CurrentArrow.Shot(_arrowSpeed);

        ArrowAudio.pitch = Random.Range(0.8f, 1.2f);
        ArrowAudio.Play();
    }
}
