using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class PlayerData : UIController
{
   
    [SerializeField] public string Name { get; private set; }
    private Animator _animator;
    private UserNameTagUI _tagUI;

    public Scrollbar scrollbar;
    public TMP_InputField inputField;

    protected override void Awake()
    {
        base.Awake();
        _tagUI = GetComponent<UserNameTagUI>();
        _animator = GetComponent<Animator>();
        inputField.characterLimit = 10;
        inputField.text = "";//TODO ÇÃ·¹ÀÌ¾î Á¤º¸ ºÒ·¯¿À±â
    }

    private void Start()
    {
        if (inputField.text == "")
            SetPlayerData();
    }

    public void InputName()
    {
        inputField.onValueChanged.AddListener((text) => inputField.text = Regex.Replace(text, @"[^0-9a-zA-Z°¡-ÆR]", ""));
    }

    public void SetPlayerData()
    {
        _tagUI.Disable();
        Active();
        scrollbar.value = 0;
        inputField.text = "";
    }

    public void OnExit()
    {
        if (Name != null)
            Disabled();
    }

    public void PlayerDataChange()
    {
        bool isPlayer = _animator.GetBool("isPlayer1");
        if (inputField.text.Length < 2 &&(isPlayer == (scrollbar.value >= 0.5f) || !isPlayer == (scrollbar.value < 0.5f)))
            return;
        if (inputField.text.Length > 1 && Name != inputField.text)
            Name = inputField.text;
        _tagUI.ChangName(Name);
        switch(scrollbar.value)
        {
            case < 0.5f:
                {
                    _animator.SetBool("isPlayer1", false);
                    break;
                }
            case >= 0.5f:
                {
                    _animator.SetBool("isPlayer1", true);
                    break;
                }
        }
        OnExit();
    }
}
