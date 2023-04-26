using UnityEngine;

public class Guides : MonoBehaviour
{
    private Transform _target;
    private void Start()
    {
        ColonyHP colonyHP = FindFirstObjectByType<ColonyHP>();
        _target = colonyHP.GetTarget();
    }

    void Update()
    {
        transform.LookAt(_target);
    }
}
