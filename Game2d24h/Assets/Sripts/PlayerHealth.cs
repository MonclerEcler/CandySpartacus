using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float totalHealth = 200f;
    
    private float _health;

    private void Start()
    {
        _health = totalHealth;
    }

    private void Update()
    {
        InitHealth();
    }

    public void ReduceHealth(float damage)
    {
        _health -= damage;
        hitSound.Play();
        InitHealth();
        _animator.SetTrigger("takeDamage");

        if (_health <= 0f)
        {
            Die();
        }
    }

    private void InitHealth()
    {
        healthSlider.value = _health / totalHealth;
    }
    private void Die()
    {
        gameObject.SetActive(false);
        gameOverCanvas.SetActive(true);
    }
}