using TMPro;
using UnityEngine;

public class UserNameTagUI : UIController
{
    public TextMeshProUGUI textPro;
    public string Name = "";
     protected override void Awake()
    {
        base.Awake();
        if (Name != "")
            ChangName(Name);
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
