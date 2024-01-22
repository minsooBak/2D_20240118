using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event Action<Vector2> MoveEvent;
    public event Action<Vector2> LookEvent;
    public event Action JumpEvent;

    [SerializeField]
    private bool canMove = true;

    public void SetMove(bool move) => canMove = move;

    public void CallMoveEvent(Vector2 data)
    {
        if (canMove)
            MoveEvent?.Invoke(data);
    }

    public void CallLookEvent(Vector2 data)
    {
        if (canMove)
            LookEvent?.Invoke(data);
    }

    public void CallJumpEvent()
    {
        if (canMove)
            JumpEvent?.Invoke();
    }
}
