using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    #region
    public static Transform instance;

    private void Awake()
    {
        instance = this.transform;
    }
    #endregion

    public PlayerHolder PlayerHolder;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private FloatingJoystick _joystick;

    [SerializeField] private Transform BulletSpawn;
    [SerializeField] private GameObject BulletPrefab;

    private List<GameObject> _bulletList;
    
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();

        CreatBulletForHierarchy();
        StartCoroutine(AutoShooting());
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * PlayerHolder._moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * PlayerHolder._moveSpeed); 
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetBool("isMoving", true);
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }
    }

    private IEnumerator AutoShooting()
    {
        while (true)
        {
            if (_animator.GetBool("isMoving") == false & GameObject.FindWithTag("Enemy") == true)
            {
                for (int i = 0; i < _bulletList.Count; i++)
                {
                    if (!_bulletList[i].activeInHierarchy)
                    {
                        _bulletList[i].transform.position = BulletSpawn.transform.position;
                        _bulletList[i].transform.rotation = BulletSpawn.transform.rotation;
                        _bulletList[i].SetActive(true);
                        Rigidbody tempRigidBodyBullet = _bulletList[i].GetComponent<Rigidbody>();
                        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * PlayerHolder._bulletSpeed);
                        break;

                    }
                }
            }
            yield return new WaitForSeconds(PlayerHolder._bulletSpawnSpeed);
        }
    }

    private void CreatBulletForHierarchy()
    {
        _bulletList = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(BulletPrefab);
            objBullet.SetActive(false);
            _bulletList.Add(objBullet);
        }
    }

}
