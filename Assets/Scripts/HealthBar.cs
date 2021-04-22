using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _damage;
    [SerializeField] private float _health;

    private Slider _healthBar;
    private float _targetValue;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _targetValue = _healthBar.value;
    }

    private void Update()
    {
        if (_healthBar.value != _targetValue)
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _targetValue, 0.1f);
    }

    public void TakeDamage()
    {
        if (_healthBar.value > _healthBar.minValue)
            _targetValue -= _damage;
    }

    public void TakeHealth()
    {
        if (_healthBar.value < _healthBar.maxValue)
            _targetValue += _health;
    }
}
