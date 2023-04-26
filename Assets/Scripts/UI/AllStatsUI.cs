using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AllStatsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _maxAmmoText;
    [SerializeField] private TMP_Text _ammoText;
    [SerializeField] private TMP_Text _arrowSpeedText;
    [SerializeField] private TMP_Text _damageText;

    private void Start()
    {

        Stats.Instance.OnMaxAmmoChange += Display;
        Stats.Instance.OnAmmoChange += Display;

        Display();
    }

    private void Display()
    {
        _arrowSpeedText.text = Stats.Instance.ArrowSpeed.ToString();
        _damageText.text = Stats.Instance.Damage.ToString();
    }

    private void OnDestroy()
    {
        Stats.Instance.OnMaxAmmoChange -= Display;
        Stats.Instance.OnAmmoChange -= Display;
    }
}
