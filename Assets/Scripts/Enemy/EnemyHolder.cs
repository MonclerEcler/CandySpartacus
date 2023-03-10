using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats Holder", menuName = "ScriptableObject Enemy/ Enemy")]

public class EnemyHolder : ScriptableObject
{
    [Header("Player")]
    public string nameEnemy;

    [Header("Health")]
    public int _maxEnemyHealth;
    public int _damageToPlayer;
    public GameObject Prefab;
}
