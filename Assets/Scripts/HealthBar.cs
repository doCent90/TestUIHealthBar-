using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Text))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _healthPoints;
    [Header("Value of speed")]
    [SerializeField] private float _speed;

    private Slider _healthBar;
    private Text _points;
    private float _maxHealth;
    private float _currentHealth;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _points = GetComponent<Text>();
        _maxHealth = _healthPoints.GetComponent<HealthPoints>().MaxHealth;
        SetMaxValuesHealth();
    }

    private IEnumerator MoveHandle(WaitForFixedUpdate waitForFixedUpdate)
    {
        while (_healthBar.value != _currentHealth)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _currentHealth, Time.deltaTime * _speed);
            _points.text = $"{_currentHealth}";
            yield return waitForFixedUpdate;
        }

        StopCoroutine(MoveHandle(waitForFixedUpdate));
    }
    
    private void SetMaxValuesHealth()
    {
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _maxHealth;
        _currentHealth = _maxHealth;
        _points.text = $"{_maxHealth}";
    }

    public void SetHealthPoints()
    {
        _currentHealth = _healthPoints.GetComponent<HealthPoints>().Health;
    }

    public void SetHandlePosition()
    {
        var waitForFrame = new WaitForFixedUpdate();

        StartCoroutine(MoveHandle(waitForFrame));     
    }
}