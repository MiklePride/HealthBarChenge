using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _maxHealth = 100;
    private float _health;

    public static UnityAction<int> HealthChenged;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void Heal()
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
        int minHealth = 0;
        _health += Mathf.Clamp(value, minHealth, _maxHealth);

        HealthChenged.Invoke(value);
    }
}
