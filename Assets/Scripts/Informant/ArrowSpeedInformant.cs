using TMPro;
using UnityEngine;

public class ArrowSpeedInformant : MonoBehaviour, IInformant
{
    [SerializeField] private ArrowSpeedUpdate _arrowSpeedUpdate;

    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private TMP_Text _infoText;

    private void Awake()
    {
        _arrowSpeedUpdate.OnCostChange += Display;
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
        _infoText.text = $"Press \"E\" to increase arrow speed by {_arrowSpeedUpdate.extraSpeed}, cost {_arrowSpeedUpdate.cost}";
    }

    private void OnDestroy()
    {
        _arrowSpeedUpdate.OnCostChange -= Display;
    }
}
