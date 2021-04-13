using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorAlarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief rogue))
        {
            _alarm.Invoke();
        }
    }
}
