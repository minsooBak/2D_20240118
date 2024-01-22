using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue data)
    {
        Vector2 dir = data.Get<Vector2>().normalized;
        CallMoveEvent(dir);
    }

    public void OnLook(InputValue data)
    {
        Vector2 worldPos = _camera.ScreenToViewportPoint(data.Get<Vector2>() - (Vector2)transform.position);
        CallLookEvent(worldPos);
    }

    public void OnJump()
    {
        CallJumpEvent();
    }
}
