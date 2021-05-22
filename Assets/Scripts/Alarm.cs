using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private House _house;

    public event UnityAction AlarmSound;

    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _house.ThiefInvasion += OnThiefInvasion;
    }

    private void OnDisable()
    {
        _house.ThiefInvasion -= OnThiefInvasion;
    }

    private void OnThiefInvasion()
    {
        _alarm.Play();
        AlarmSound?.Invoke();
    }
}
