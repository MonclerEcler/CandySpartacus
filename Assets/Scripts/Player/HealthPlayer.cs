using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] PlayerHolder PlayerHolder;
    [SerializeField] private GameObject _gameOverCanvas;

    private int _currentPlayerHealth;

    public event Action<float> PlayerHealthChanged;

    private void Start() => _currentPlayerHealth =this.PlayerHolder._maxPlayerHealth;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WeaponEnemy") 
        {
            ChangeHealthPlayer();
        }
    }

    private void ChangeHealthPlayer()
    {
        _currentPlayerHealth -= this.PlayerHolder._damageToEnemy;

        if (_currentPlayerHealth <= 0)
        {
            DeathPlayer();
        }
        else
        {
            float _currentHealthAsPercantage = (float)_currentPlayerHealth / this.PlayerHolder._maxPlayerHealth;
            PlayerHealthChanged?.Invoke(_currentHealthAsPercantage);
        }
    }

    private void DeathPlayer()
    {
        PlayerHealthChanged?.Invoke(0);
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
