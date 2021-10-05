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
    private bool _isAlarmPlayed = false;
    

    private void Start()
    {
        _runAwaySpeed = _speed;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _speed);

        if (_isAlarmPlayed)
        {
            RunAway();
        }
        else
        {
            MoveToTarget();
        }
    }

    private void RunAway()
    {
        _speed = _runAwaySpeed;
        transform.Translate(transform.position.x * _speed * Time.deltaTime, 0, 0);
    }

    private void MoveToTarget()
    {
        if (transform.position != _target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
        else
        {
            _speed = 0;
            _animator.SetTrigger("Attack");
        }
    }

    private void OnEnable()
    {
        _alarm.AlarmActivated += OnAlarmSound;
    }

    private void OnDisable()
    {
        _alarm.AlarmActivated -= OnAlarmSound;
    }

    private void OnAlarmSound()
    {
        _isAlarmPlayed = true;
    }
}
