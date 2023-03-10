using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void HideBullet()
    {
        transform.GetComponent<Rigidbody>().Sleep();
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            transform.GetComponent<Rigidbody>().WakeUp();
            Invoke("HideBullet", 0f);
        }
        else
            Invoke("HideBullet", 1f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
