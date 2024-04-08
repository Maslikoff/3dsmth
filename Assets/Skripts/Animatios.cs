using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatios : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckKeyForAnim();
    }

    private void CheckKeyForAnim()
    {
        if (Input.GetKey(KeyCode.Space))
            animator.Play("Jump");

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            animator.Play("Run");

        if (Input.GetMouseButtonDown(0))
            animator.Play("Attack");

        if (Input.GetKey(KeyCode.E))
            animator.Play("Talking");

        if (Input.GetKey(KeyCode.Alpha1))
            animator.Play("Death");
    }
}
