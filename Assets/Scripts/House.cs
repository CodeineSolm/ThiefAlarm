using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    public event UnityAction ThiefInvasion;
    public event UnityAction ThiefEscape;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            ThiefInvasion.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            ThiefEscape.Invoke();
        }
    }
}
