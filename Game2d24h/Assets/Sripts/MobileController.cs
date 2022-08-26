using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    [SerializeField] private AttackController attackController;
    [SerializeField] private PlayerController playerController;


    public void Attack()
    {
        attackController.Attack();
    }

    public void Jump()
    {
        playerController.Jump();
    }

    public void Interact()
    {
        playerController.Interact();
    }
   
}
