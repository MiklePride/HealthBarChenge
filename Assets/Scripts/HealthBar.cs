using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]                                                                             

public class HealthBar : MonoBehaviour
{
    private Coroutine _drowHealth;
    private Image _healthBarFilling;
    private float _duration = 0.5f;

    private void Awake()
    {
        _healthBarFilling = GetComponent<Image>();
    }

    private void OnEnable()
    {
        Player.HealthChenged += OnChengeHealth;
    }

    private void OnDestroy()
    {
        Player.HealthChenged -= OnChengeHealth;
    }

    public void OnChengeHealth(int value)
    {
        float maxPercent = 100f;
        float valueAsPercentage = value / maxPercent;

        float targetValue = Mathf.Clamp01(_healthBarFilling.fillAmount + valueAsPercentage);

        if (_drowHealth != null) 
        {
            StopCoroutine(_drowHealth);
        }

        _drowHealth = StartCoroutine(DrowHealth(targetValue));
    }

    private IEnumerator DrowHealth(float targetValue)
    {
        while (_healthBarFilling.fillAmount != targetValue)
        {
            _healthBarFilling.fillAmount = Mathf.MoveTowards(_healthBarFilling.fillAmount, targetValue, _duration * Time.deltaTime);

            yield return null;
        }
    }
}
