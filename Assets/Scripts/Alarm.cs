using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private House _house;

    private AudioSource _alarm;
    private bool _isActivated;
    private float _volumeChange = 0.3f;

    public event UnityAction AlarmActivated;

    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
        _alarm.volume = 0;
    }

    private void Update()
    {
            ChangeVolume();
    }

    private void OnEnable()
    {
        _house.ThiefInvasion += OnThiefInvasion;
        _house.ThiefEscaped += OnThiefEscape;
    }

    private void OnDisable()
    {
        _house.ThiefInvasion -= OnThiefInvasion;
        _house.ThiefEscaped -= OnThiefEscape;
    }

    private void OnThiefInvasion()
    {
        _alarm?.Play();
        _isActivated = true;
    }

    private void OnThiefEscape()
    {
        _isActivated = false;
    }

    private void ChangeVolume()
    {
        if (_isActivated)
        {
            _alarm.volume += _volumeChange * Time.deltaTime;

            if (_alarm.volume == 1f)
                AlarmActivated?.Invoke();
        }
        else
        {
            _alarm.volume -= _volumeChange * Time.deltaTime;

            if (_alarm.volume == 0)
                _alarm?.Stop();
        }
    }
}
