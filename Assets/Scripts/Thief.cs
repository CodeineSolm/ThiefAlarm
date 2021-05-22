using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;
    [SerializeField] private Alarm _alarm;

    private float _runAwaySpeed;
    private Animator _animator;
    private Transform _transform;
    private bool _isAlarm = false;
    

    private void Start()
    {
        _runAwaySpeed = _speed;
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _speed);

        if (_isAlarm)
        {
            MoveAway();
        }
        else
        {
            MoveToTarget();
        }
    }

    private void MoveAway()
    {
        _speed = _runAwaySpeed;
        _transform.Translate(_transform.position.x * _speed * Time.deltaTime, 0, 0);
    }

    private void MoveToTarget()
    {
        if (_transform.position != _target.position)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _target.position, _speed * Time.deltaTime);
        }
        else
        {
            _speed = 0;
        }
    }

    private void OnEnable()
    {
        _alarm.AlarmSound += OnAlarmSound;
    }

    private void OnDisable()
    {
        _alarm.AlarmSound -= OnAlarmSound;
    }

    private void OnAlarmSound()
    {
        _isAlarm = true;
    }
}
