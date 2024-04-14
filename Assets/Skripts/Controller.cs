using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Controller : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private new Transform camera;

    private Quaternion _targetRotation;
    private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        JumpLogic();
        Attack();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Abs(horizontal) + Mathf.Abs(vertical);

        var moveInput = (new Vector3(horizontal, 0, vertical)).normalized;

        var moveDir = camera.rotation * moveInput;

        if (moveAmount > 0)
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
            _targetRotation = Quaternion.LookRotation(moveDir);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, rotationSpeed * Time.deltaTime);

        if (_isGrounded)
            if (horizontal != 0 || vertical != 0)
                _animator.Play("Run");
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _animator.Play("Jump");
                _rigidbody.velocity += Vector3.up * jumpForce;
            }
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
            _animator.Play("Attack");
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = value;
        }
    }
}
