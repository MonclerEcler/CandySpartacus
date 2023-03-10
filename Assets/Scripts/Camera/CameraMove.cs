using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpRotate = 10f;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _lerpRotate);
        transform.position = _target.position;
    }
}
