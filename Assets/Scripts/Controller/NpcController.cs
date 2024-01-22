using System;
using UnityEngine;

public class NpcController : CharacterController
{
    [SerializeField] private LayerMask target;
    [SerializeField] private string Name;
    protected bool isEnter = false;
    [SerializeField] private CharacterController _controller;
    private TalkManager _TM;
    private void Awake()
    {
        _TM = TalkManager.Instance;
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _controller.JumpEvent += Jump;
    }

    private void Jump()
    {
        if (isEnter)
            _TM.OnTalk(Name);
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
