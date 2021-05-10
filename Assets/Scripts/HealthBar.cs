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

    private WaitForFixedUpdate waitForFixed;
    private HealthPoints _currentHealth;
    private Slider _healthBar;
    private Text _points;
    private float _maxHealth;

    private void Start()
    {
        _points = GetComponent<Text>();
        _healthBar = GetComponent<Slider>();
        _currentHealth = _healthPoints.GetComponent<HealthPoints>();
        _maxHealth = _currentHealth.MaxHealth;
        waitForFixed = new WaitForFixedUpdate();

        SetMaxValuesHealth();
    }

    private IEnumerator MoveHandle(WaitForFixedUpdate waitForFixedUpdate)
    {
        while (_healthBar.value != _currentHealth.Health)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _currentHealth.Health, Time.deltaTime * _speed);
            yield return waitForFixedUpdate;
        }

        _points.text = $"{_currentHealth.Health}";
        StopCoroutine(MoveHandle(waitForFixedUpdate));
    }
    
    private void SetMaxValuesHealth()
    {
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _maxHealth;
        _points.text = $"{_maxHealth}";
    }

    public void ActivateEvent()
    {
        StartCoroutine(MoveHandle(waitForFixed));     
    }
}