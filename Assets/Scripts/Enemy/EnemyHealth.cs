using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private  EnemyHolder EnemyHolder;
    private int _currentEnemyHealth;

    public event Action<float> EnemyHealthChanged;

    private void Start() => _currentEnemyHealth = this.EnemyHolder._maxEnemyHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            ChangeHealthEnemy();
        }
    }

    public void ChangeHealthEnemy()
    {
        _currentEnemyHealth -= this.EnemyHolder._damageToPlayer;

        if (_currentEnemyHealth <= 0)
        {
            DeathEnemy();
        }
        else
        {
            float _currentHealthAsPercantage = (float)_currentEnemyHealth / this.EnemyHolder._maxEnemyHealth;
            EnemyHealthChanged?.Invoke(_currentHealthAsPercantage);
        }
    }

    private void DeathEnemy()
    {
        EnemyHealthChanged?.Invoke(0);
        Destroy(gameObject);
    }
}
