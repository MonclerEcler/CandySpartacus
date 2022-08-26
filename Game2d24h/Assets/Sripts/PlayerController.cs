using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    [SerializeField] private Animator animator;
    [SerializeField] private Transform playerModelTransform;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private float speedx;

    
    private float _horizontal = 0f;
    private bool _isGround = false;
    private bool _isJump = false;
    private bool _isFacingRight = true;
    private bool _isFinish = false;
    private bool _isLeverArm = false;

    private FixedJoystick _fixedJoystick;
    private Finish _finish;
    private Rigidbody2D _rb;
    private LeverArm _leverArm;
    const float speedxMultiPlayer = 50f;
    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
        _fixedJoystick = GameObject.FindGameObjectWithTag("Fixed Joystick").GetComponent<FixedJoystick>();
        _leverArm = FindObjectOfType<LeverArm>();

    }

    void Update()
    {
        //_horizontal = Input.GetAxis("Horizontal");
        _horizontal = _fixedJoystick.Horizontal;
        animator.SetFloat("speedx", Mathf.Abs(_horizontal));
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            Jump();
        }

        if (_horizontal > 0f && !_isFacingRight)
        {
            Flip();
        }

        else if (_horizontal < 0f && _isFacingRight)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = playerModelTransform.localScale;
        playerScale.x *= -1f;
        playerModelTransform.localScale = playerScale;

    }


    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * speedx * speedxMultiPlayer * Time.fixedDeltaTime, _rb.velocity.y);

        if (_isJump)
        {
            _rb.AddForce(new Vector2(0f, 400f));
            _isGround = false;
            _isJump = false;
        }
    }
    public void Jump()
    {
        if (_isGround)
        {
            _isJump = true;
            jumpSound.Play();
        }
    }
    public void Interact()
    {
        if (_isFinish)
        {
            _finish.FinishLevel();
        }
        if (_isLeverArm)
        {
            _leverArm.ActivateLeverArm();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LeverArm leverArmTemp = other.GetComponent<LeverArm>();
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Worked");
            _isFinish = true;
        }
        if (leverArmTemp != null)
        {
            _isLeverArm = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        LeverArm leverArmTemp = other.GetComponent<LeverArm>();
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log(" Not Worked");
            _isFinish = false;
        }
        if (leverArmTemp != null)
        {
            _isLeverArm = false;
        }
    }
  
}
