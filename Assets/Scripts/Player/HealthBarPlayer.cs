using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] private HealthPlayer HealthPlayer;
    [SerializeField] private Gradient _gradient;

    private Camera _camera;

    private void Awake()
    {
        HealthPlayer.PlayerHealthChanged += OnHealthChanged;
        _healthBarFilling.color = _gradient.Evaluate(1);
        _camera = Camera.main;
    }

    private void OnDestroy() => HealthPlayer.PlayerHealthChanged -= OnHealthChanged;

    private void OnHealthChanged(float valueAsPercantage)
    {
        _healthBarFilling.fillAmount = valueAsPercantage;
        _healthBarFilling.color = _gradient.Evaluate(valueAsPercantage);
    }

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
        transform.Rotate(0, 180, 0);
    }
}
