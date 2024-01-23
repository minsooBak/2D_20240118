using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    private static TalkManager _instance;
    public static TalkManager Instance { get { return _instance; } }

    [SerializeField] private GameObject obj;
    [SerializeField] private TalkDatas talkDatas;
    [SerializeField] private TextMeshProUGUI textMain;
    public List<Sprite> currentImg;
    public Image img;
    private CharacterController player;
    private SpriteRenderer playerImg;
    private string targetName = "";

    [SerializeField]private float delay = 0.15f;
    [SerializeField]private int page = 0;
    bool isTalk = false;

    private void Awake()
    {
        if(_instance == null)
            _instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
        talkDatas.Init();
        var p = GameObject.FindGameObjectWithTag("Player");
        player = p.GetComponent<CharacterController>();
        playerImg = p.GetComponentInChildren<SpriteRenderer>();
    }

    public void OnTalk(string name = "")
    {
        if (isTalk || (targetName == "" && name == ""))
            return;
        targetName = name == "" ? targetName : name;
        var a = talkDatas.talks[targetName.GetHashCode()];

        if (a.Count == page)
        {
            IsActive(false);
            player.SetMove(true);
            page = 0;
            targetName = "";
            textMain.text = "";
            return;
        }
        IsActive(true);
        player.SetMove(false);
       
        if (a[page].Name == "Player")
            img.sprite = playerImg.sprite;
        else if (a[page].Name == "Test1")
            img.sprite = currentImg[0];
        else
            img.sprite = currentImg[1];

        if(page <= a.Count - 1 && isTalk == false)
        {
            textMain.text = "";
            StartCoroutine(Talk(a[page++].Talk));
        }
    }

    IEnumerator Talk(string talk)
    {
        isTalk = true;
        foreach (char text in talk)
        {
            textMain.text += text;
            yield return new WaitForSecondsRealtime(delay);
        }
        isTalk = false;
        StopCoroutine("Talk");
        yield return null;
    }

    void IsActive(bool isActive)
    {
        obj.SetActive(isActive);
    }
}
