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

    private List<TalkData> current;
    private CharacterController player;
    private SpriteRenderer playerImg;

    [SerializeField]private float delay = 0.15f;
    [SerializeField] private int page = 0;
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
        playerImg = p.GetComponent<SpriteRenderer>();
    }

    public void OnTalk(string name)
    {
        if (current.Count == 0)
        {
            talkDatas.talks.TryGetValue(name.GetHashCode(), out current);
            page = 0;
        }
        IsActive(true);
        player.SetMove(false);

        if (current[page].name == "Player")
            img.sprite = playerImg.sprite;
        while(page >= current.Count && isTalk == false)
        { 
            StartCoroutine("Talk", current[page]);
        }
    }

    IEnumerable Talk(string talk)
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

    public void NextPage()
    {
        if(isTalk != false && current.Count > 0)
        {
            StartCoroutine("Talk", current[++page]);
        }
    }

    void IsActive(bool isActive)
    {
        obj.SetActive(isActive);
    }
}
