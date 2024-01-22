using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TalkManager : MonoBehaviour
{
    private static TalkManager _instance;
    public static TalkManager Instance { get { return _instance; } }

    [SerializeField] private GameObject obj;
    [SerializeField] private TalkDatas talkDatas;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textMain;

    private List<TalkData> current;
    private CharacterController player;

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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    public void OnTalk(string name)
    {
        talkDatas.talks.TryGetValue(name.GetHashCode(), out current);
        IsActive(true);
        player.SetMove(false);

        textName.text = current[page].Name;
        while(page >= current.Count && isTalk == false)
        { 
            StartCoroutine("Talk", current[page]);
        }
        page = 0;
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

    public void OnJump()
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
