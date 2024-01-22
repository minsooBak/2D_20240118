using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _controller;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private float speed = 5f;
    private Vector2 dir = Vector2.zero;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        _controller.MoveEvent += GetMove;
        _controller.LookEvent += GetLook;
    }

    private void FixedUpdate()
    {
        Move(dir);
    }

    public virtual void GetMove(Vector2 data)
    {
        dir = data ;
    }

    public void GetLook(Vector2 data)
    {
        _spriteRenderer.flipX = data.x > 0.5 ? false : true;
    }


    private void Move(Vector2 d)
    {
        d = speed * Time.fixedDeltaTime * d;
        _rigidbody.velocity = d;
    }
}
