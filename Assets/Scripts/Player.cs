using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> _healthChenged;

    private int _maxHealth = 100;
    private float _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void Healing()
    {
        int healPoint = 10;

        ChengeHealth(healPoint);
    }

    public void TakeDamage()
    {
        int damagePoint = -10;

        ChengeHealth(damagePoint);
    }

    private void ChengeHealth(int value)
    {
        _health += value;

        if (_health < 0)
            _health = 0;

        if (_health > _maxHealth)
            _health = _maxHealth;

        _healthChenged.Invoke(value);
    }
}
