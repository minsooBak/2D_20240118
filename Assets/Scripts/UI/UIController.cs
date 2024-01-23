using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    private CharacterController _controller;

    protected virtual void Awake()
    {
        _controller = GetComponent<CharacterController>();
        obj.SetActive(false);
    }

    protected void Active()
    {
        _controller.SetMove(false);
        obj.SetActive(true);
    }

    protected void Disabled()
    {
        _controller.SetMove(true);
        obj.SetActive(false);
    }

    protected void MoveActive()
    {
        obj.SetActive(true);
    }
}
