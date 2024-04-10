using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State { Idle, Walk, Run}

    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 5f;

    private State _state;
    private Rigidbody _rigidbody;
    private Vector3 _moveVector;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetState(State newState)
    {
        EnterState(_state);
        ExitState(newState);
    }

    private void EnterState(State newState)
    {
        switch (newState)
        {
            case State.Idle:
                animator.Play("Idle");
                break;
            case State.Walk:
                animator.Play("Walk");
                //MovePlayer();
                break;
            case State.Run:
                animator.Play("Run");
                MovePlayer();
                break;
            default:
                break;
        }
        _state = newState;
    }

    private void ExitState(State oldState)
    {
        switch (oldState)
        {
            case State.Idle:
                break;
            case State.Walk:
                break;
            case State.Run:
                break;
            default:
                break;
        }
    }

    private void MovePlayer()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _moveVector.z = Input.GetAxis("Vertical");
        _rigidbody.MovePosition(_rigidbody.position + _moveVector * speed * Time.deltaTime);
    }
}
