using TMPro;
using UnityEngine;

public class ChestInformant : MonoBehaviour, IInformant
{
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private TMP_Text _infoText;

    private void Start()
    {
        HideInfo();
    }

    public void ShowInfo()
    {
        _infoPanel.SetActive(true);
        Display();
    }

    public void HideInfo()
    {
        _infoPanel.SetActive(false);
    }

    public void Display()
    {
        _infoText.text = "Press \"E\" to replenish ammo";
    }
}
