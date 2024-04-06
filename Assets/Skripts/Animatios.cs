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
        CheckNumbersForAnim();
    }

    private void CheckNumbersForAnim()
    {
        if (Input.GetKey(KeyCode.Space))
            animator.Play("Jump");

        if (Input.GetKey(KeyCode.Alpha2))
            animator.Play("Run");

        if (Input.GetMouseButtonDown(0))
            animator.Play("Attack");

        if (Input.GetKey(KeyCode.Alpha4))
            animator.Play("Talking");

        if (Input.GetKey(KeyCode.Alpha5))
            animator.Play("Death");
    }
}
