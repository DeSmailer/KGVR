using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColonyHPUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _guiText;
    [SerializeField] private Slider _slider;

    [SerializeField] private ColonyHP _colonyHP;

    private void Start()
    {
        _colonyHP.OnDamageTaken += DisplayHP;
        _colonyHP.OnDie += DisplayLose;

        _guiText.gameObject.SetActive(false);

        DisplayHP();
    }

    private void DisplayHP()
    {
        _slider.value = _colonyHP.hp / _colonyHP.maxHP;
    }

    private void DisplayLose()
    {
        _guiText.text = "You Lose";

        _guiText.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        _colonyHP.OnDamageTaken -= DisplayHP;
        _colonyHP.OnDie -= DisplayLose;
    }
}