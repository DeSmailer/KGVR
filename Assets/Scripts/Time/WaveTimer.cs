using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class WaveTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _guiText;
    [SerializeField] private WaveController _waveController;

    private void Start()
    {
        _waveController.OnNewWaveThrough += NewWaveOverTime;
    }

    public void NewWaveOverTime(int wave, float time)
    {
        StopAllCoroutines();
        StartCoroutine(NewWaveOverTimeCoroutine(wave, time));
    }

    private IEnumerator NewWaveOverTimeCoroutine(int wave, float time)
    {
        float timer = time;

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            _guiText.text = $"Wave {wave} in \n" + TimeSpan.FromSeconds(timer).ToString(@"ss\:ff") + " seconds";

            yield return null;
        }

        _guiText.text = $"Wave {wave}";
    }

    private void OnDestroy()
    {
        _waveController.OnNewWaveThrough -= NewWaveOverTime;
    }
}
