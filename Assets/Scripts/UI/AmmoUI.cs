using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    private TMP_Text _guiText;

    private void Awake()
    {
        _guiText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        Stats.Instance.OnMaxAmmoChange += Display;
        Stats.Instance.OnAmmoChange += Display;

        Display();
    }

    private void Display()
    {
        _guiText.text = Stats.Instance.Ammo.ToString() + "/" + Stats.Instance.MaxAmmo.ToString();
    }

    private void OnDestroy()
    {
        Stats.Instance.OnMaxAmmoChange -= Display;
        Stats.Instance.OnAmmoChange -= Display;
    }
}
