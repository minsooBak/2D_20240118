using System;
using UnityEngine;

public class NpcController : CharacterController
{
    [SerializeField] private LayerMask target;
    [SerializeField] private string Name;
    protected bool isEnter = false;
    [SerializeField] private CharacterController _controller;
    private void Awake()

    {
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _controller.JumpEvent += Jump;
    }

    private void Jump()
    {
        CallJumpEvent();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnter)
            return;

        if(target.value == (target.value | (1 << collision.gameObject.layer)))
        {
            isEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(target.value == (target.value | (1 << collision.gameObject.layer)))
        {
            isEnter = false;
        }
    }
}
