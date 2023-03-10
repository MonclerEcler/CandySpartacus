using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats Holder", menuName = "ScriptableObject Player/ Player")]

public class PlayerHolder : ScriptableObject
{
    [Header("Player")]
    public string nameCharacter;
    public float _moveSpeed;

    [Header("Health")]
    public int _maxPlayerHealth;
    public int _damageToEnemy;
    public GameObject Prefab;

    [Header("Bullet")]
    public float _bulletSpawnSpeed;
    public float _bulletSpeed;

}
