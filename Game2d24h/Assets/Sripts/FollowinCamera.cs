using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowinCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

     void LateUpdate()
    {
        cameraTransform.position = new Vector3(transform.position.x, transform.position.y+2, cameraTransform.position.z);
    }
}
