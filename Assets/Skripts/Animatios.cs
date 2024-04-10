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

    public void CheckKeyForAnim()
    {
        if (Input.GetKey(KeyCode.E))
            animator.Play("Talking");

        if (Input.GetKey(KeyCode.Alpha1))
            animator.Play("Death");
    }
}
