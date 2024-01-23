using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    private Camera _camera;
    private TalkManager _TM;

    [SerializeField] private LayerMask _target;
    [SerializeField] private string _targetName = "";
    CharacterController targetController;
    private bool _isEnter = false;
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        _TM = TalkManager.Instance;
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
        _TM.OnTalk(_targetName);
        CallJumpEvent();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isEnter)
            return;

        if (_target.value == (_target.value | (1 << collision.gameObject.layer)))
        {
            _targetName = collision.gameObject.name.Split("_")[1];
            targetController = collision.gameObject.GetComponent<CharacterController>();
            targetController.SetMove(true);
            targetController.CallJumpEvent();
            _isEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_target.value == (_target.value | (1 << collision.gameObject.layer)))
        {
            _targetName = "";
            if (targetController != null)
            {
                targetController.SetMove(false);
                targetController = null;
            }
            _isEnter = false;
        }
    }
}
