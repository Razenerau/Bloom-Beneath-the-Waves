using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    public Animator Animator;
    Vector2 moveInput = Vector2.zero;

    public void Move()//InputAction.CallbackContext c)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(horizontal != 0 || vertical != 0)
        {
            Animator.SetBool("isMoving", true);
        }
        else
        {
            Animator.SetBool("isMoving", false);
        }

        if (Mathf.Abs(horizontal) > 0.01f || Mathf.Abs(vertical) > 0.01f) 
        {
            Animator.SetFloat("lastInputX", horizontal);
            Animator.SetFloat("lastInputY", vertical);
        }

        Animator.SetFloat("inputX", horizontal);
        Animator.SetFloat("inputY", vertical);
    }

    private void Update()
    {
        Move();
    }
}
