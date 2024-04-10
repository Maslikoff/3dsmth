using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Controller : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform cam;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float jumpForce = 12f;

    private Rigidbody _rigidbody;
    private Vector3 moveDirection;
    private bool _isGrounded;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovePlayer();
        JumpLogic();
        Attack();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _rigidbody.velocity = moveDir * speed;

            if (horizontal != 0 || vertical != 0)
                animator.Play("Run");
            else
                animator.Play("Idle");
        }
        else
        {
            _rigidbody.velocity = Vector3.zero; // Устанавливаем скорость равной нулю, если клавиши не нажаты
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _rigidbody.velocity += Vector3.up * jumpForce;
                //_rigidbody.AddForce(Vector3.up * jumpForce);
                animator.Play("Jump");
            }
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
            animator.Play("Attack");
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
