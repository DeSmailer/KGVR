using UnityEngine;

public class InteractionWithWorld : MonoBehaviour
{
    [SerializeField] private IUsable usable = null;
    [SerializeField] private IInformant informant = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IUsable>() != null)
        {
            usable = other.gameObject.GetComponent<IUsable>();
        }
        if (other.gameObject.GetComponent<IInformant>() != null)
        {
            informant = other.gameObject.GetComponent<IInformant>();
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

        if (informant != null)
        {
            if (other.gameObject.GetComponent<IInformant>() == informant)
            {
                informant.HideInfo();
                informant = null;
            }
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
