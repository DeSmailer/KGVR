using TMPro;
using UnityEngine;

public class DamageInformant : MonoBehaviour, IInformant
{
    [SerializeField] private DamageUpdate _damageUpdate;

    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private TMP_Text _infoText;

    private void Awake()
    {
        _damageUpdate.OnCostChange += Display;
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
        _infoText.text = $"Press \"E\" to increase damage by {_damageUpdate.extraDamage}, cost {_damageUpdate.cost}";
    }

    private void OnDestroy()
    {
        _damageUpdate.OnCostChange -= Display;
    }
}
