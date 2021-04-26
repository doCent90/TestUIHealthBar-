using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _damage;
    [SerializeField] private float _healing;
    [SerializeField] private float _health;
    [SerializeField] private float _maxDelta;

    private Slider _healthBar;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = _health;
        _healthBar.value = _health;
    }

    private void Update()
    {
        if (_healthBar.value != _health)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _health, _maxDelta);
        }
    }

    public void TakeDamage()
    {
        if (_health > _healthBar.minValue)
        {
            _health -= _damage;
        }
    }

    public void TakeHealth()
    {
        if (_health < _healthBar.maxValue)
        {
            _health += _healing;        
        }
    }
}
