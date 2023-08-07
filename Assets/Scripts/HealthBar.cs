using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]                                                                             

public class HealthBar : MonoBehaviour
{
    private Image _healthBarFilling;
    private float _duration = 0.5f;

    private void Awake()
    {
        _healthBarFilling = GetComponent<Image>();
    }

    public void ChengeHealth(int value)
    {
        float maxPercent = 100f;
        float valueAsPercentage = value / maxPercent;

        float targetValue = Mathf.Clamp01(_healthBarFilling.fillAmount + valueAsPercentage);

        StartCoroutine(DrowHealth(targetValue));
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
