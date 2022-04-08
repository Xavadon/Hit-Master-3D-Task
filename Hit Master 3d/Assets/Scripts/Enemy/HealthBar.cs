using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;

    public void SetHealth(float _health, float _maxHealth)
    {
        float fillAmount = _health / _maxHealth;
        _healthBar.fillAmount = fillAmount;
    }
}
