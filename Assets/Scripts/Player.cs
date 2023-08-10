using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _maxHealth = 100;
    private float _health;

    public Action<int> HealthChenged;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void ChengeHealth(int value)
    {
        int minHealth = 0;
        _health += Mathf.Clamp(value, minHealth, _maxHealth);

        HealthChenged?.Invoke(value);
    }
}
