using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthPoints : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _damage;
    [SerializeField] private float _healing;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;

    [SerializeField] private UnityEvent _healthChanged;

    private Text _points;
    private float _currentHealth;
    
    public float Health => _currentHealth;
    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _points = GetComponent<Text>();
        _currentHealth = _maxHealth;
        _points.text = $"{_maxHealth}";
    }

    public void TakeDamage()
    {
        if (_currentHealth > _minHealth)
        {
            _currentHealth -= _damage;
        }

        _points.text = $"{_currentHealth}";
        _healthChanged.Invoke();
    }

    public void TakeHealth()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += _healing;
        }

        _points.text = $"{_currentHealth}";
        _healthChanged.Invoke();
    }
}
