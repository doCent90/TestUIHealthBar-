using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _healthPoints;
    [Header("Value of speed")]
    [SerializeField] private float _speed;

    private Slider _healthBar;
    private float _maxHealth;
    private float _currentHealth;


    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _maxHealth = _healthPoints.GetComponent<HealthPoints>().MaxHealth;
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
    
    public void SetHealthPoints()
    {
        _currentHealth = _healthPoints.GetComponent<HealthPoints>().Health;
    }
}
