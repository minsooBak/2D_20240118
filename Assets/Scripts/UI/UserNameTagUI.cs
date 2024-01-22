using TMPro;
using UnityEngine;

public class UserNameTagUI : UIController
{
    public TextMeshProUGUI textPro;
    private PlayerData playerData;
    [SerializeField] private string Name;
     protected override void Awake()
    {
        base.Awake();
        playerData = GetComponent<PlayerData>();
    }

    public void Disable()
    {
        Disabled();
    }

    public void ChangName(string name)
    {
        Active();
        textPro.text = name;
    }

}
