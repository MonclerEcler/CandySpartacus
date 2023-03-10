using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform _target;
    private NavMeshAgent _agent = null;
    private Animator _animator;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Start() =>  GetReferences();

    private void FixedUpdate() => MoveToTarget();

    private void MoveToTarget()
    {
        _agent.SetDestination(_target.position);
        RotateTarget();
        float distanceTo_target = Vector3.Distance(_target.position, transform.position);
        if (distanceTo_target <= 0.5f)
        {
            _animator.SetBool("isAttack", true);
        }
        else
            _animator.SetBool("isAttack", false);
    }

    public void RotateTarget()
    {
        Vector3 direction = _target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void GetReferences() => _target = PlayerController.instance;
}
