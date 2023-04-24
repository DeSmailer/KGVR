using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    private TMP_Text _guiText;

    private void Awake()
    {
        _guiText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        Stats.Instance.OnMoneyChange += Display;

        Display();
    }

    private void Display()
    {
        _guiText.text = Stats.Instance.Money.ToString();
    }

    private void OnDestroy()
    {
        Stats.Instance.OnMoneyChange -= Display;
    }
}
