using TMPro;
using UnityEngine;

public class MaxAmmoInformant : MonoBehaviour, IInformant
{
    [SerializeField] private MaxAmmoUpdate _maxAmmoUpdate;

    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private TMP_Text _infoText;

    private void Awake()
    {
        _maxAmmoUpdate.OnCostChange += Display;
    }

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
        _infoText.text = $"Press \"E\" to increase max ammo by {_maxAmmoUpdate.extraAmmo}, cost {_maxAmmoUpdate.cost}";
    }

    private void OnDestroy()
    {
        _maxAmmoUpdate.OnCostChange -= Display;
    }
}
