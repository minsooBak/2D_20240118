using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private CharacterController controller;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        controller.MoveEvent += Move;
        controller.JumpEvent += Jump;
    }

    public virtual void Move(Vector2 data)
    {
        animator.SetBool("isRun", data.magnitude > .5f);
    }

    public virtual void Jump()
    {
        animator.SetTrigger("isJump");
    }

}
