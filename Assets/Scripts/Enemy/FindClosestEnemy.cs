using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestEnemy : MonoBehaviour
{
    [SerializeField] private List<Transform> AllEnemies = new List<Transform>();

    [SerializeField] private Transform nowTarget;

    private void Start() => StartCoroutine(CheckNearEnemy());
 
    private void FixedUpdate() => Rotate();

    IEnumerator CheckNearEnemy()
    {
        while (true)
        {
            var nearestDist = float.MaxValue;
            for (int i = 0; i < AllEnemies.Count; i++)
            {
                if (Vector3.Distance(AllEnemies[i].transform.position, transform.position) < nearestDist)
                {
                    nearestDist = Vector3.Distance(AllEnemies[i].transform.position, transform.position);
                    nowTarget = AllEnemies[i];
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void Rotate()
    {
        if (GameObject.FindWithTag("Enemy") == null) { }
        if (GameObject.FindWithTag("Enemy") == true)
        {
            nowTarget = GameObject.FindWithTag("Enemy").transform;
            var lookPos = nowTarget.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 8f);
        }
    }
}