using UnityEngine;

public class DestroyerAfterTime : MonoBehaviour
{
    [SerializeField] private float _time;

    void Start()
    {
        Destroy(gameObject, _time);  
    }
}
