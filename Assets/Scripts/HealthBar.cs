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

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _points = GetComponent<Text>();
        _maxHealth = _healthPoints.GetComponent<HealthPoints>().MaxHealth;        
        SetMaxValuesHealth();
    }

    private IEnumerator MoveHandle(WaitForFixedUpdate waitForFixedUpdate, float healthPoints)
    {
        while (_healthBar.value != healthPoints)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, healthPoints, Time.deltaTime * _speed);
            _points.text = $"{healthPoints}";
            yield return waitForFixedUpdate;
        }

        StopCoroutine(MoveHandle(waitForFixedUpdate, healthPoints));
    }
    
    private void SetMaxValuesHealth()
    {
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _maxHealth;
        _points.text = $"{_maxHealth}";
    }

    public void SetHandlePosition(HealthPoints health)
    {
        var waitForFrame = new WaitForFixedUpdate();
        float healthPoints = health.Health;

        StartCoroutine(MoveHandle(waitForFrame, healthPoints));     
    }
}