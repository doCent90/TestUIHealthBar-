using UnityEngine;
using UnityEngine.Events;

public class HealthPoints : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _damage;
    [SerializeField] private float _healing;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    
    public float Health => _currentHealth;
    public float MaxHealth => _maxHealth;

    [SerializeField] private UnityEvent _healthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;        
    }

    public void TakeDamage()
    {
        if (_currentHealth > _minHealth)
        {
            _currentHealth -= _damage;
        }

        _healthChanged.Invoke();
    }

    public void TakeHealth()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += _healing;
        }

        _healthChanged.Invoke();
    }
}
