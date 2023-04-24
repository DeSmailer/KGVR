using UnityEngine;

public class InteractionWithWorld : MonoBehaviour
{
    [SerializeField] private IUsable usable = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IUsable>() != null)
        {
            usable = other.gameObject.GetComponent<IUsable>();
        }

        IInformant informant = other.gameObject.GetComponent<IInformant>();
        if (informant != null)
        {
            informant.ShowInfo();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (usable != null)
        {
            if (other.gameObject.GetComponent<IUsable>() == usable)
            {
                usable = null;
            }
        }

        IInformant informant = other.gameObject.GetComponent<IInformant>();
        if (informant != null)
        {
            informant.HideInfo();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (usable != null)
            {
                usable.Use();
            }
        }
    }
}
