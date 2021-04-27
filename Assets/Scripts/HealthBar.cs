using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _damage;
    [SerializeField] private float _healing;
    [SerializeField] private float _speed;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;

    private Slider _healthBar;
    private float _currentHealth;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _maxHealth;
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (_healthBar.value != _currentHealth)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _currentHealth, Time.deltaTime * _speed);
        }
    }

    public void TakeDamage()
    {
        if (_currentHealth > _minHealth)
        {
            _currentHealth -= _damage;
        }
    }

    public void TakeHealth()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += _healing;        
        }
    }
}
