using System;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    private TMP_Text _guiText;
    private float _time = 0;

    private void Awake()
    {
        _guiText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        _guiText.text = TimeSpan.FromSeconds(_time).ToString(@"mm\:ss");
    }
}
