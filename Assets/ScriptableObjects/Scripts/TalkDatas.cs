using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu]
public class TalkDatas : ScriptableObject
{
    private readonly List<TalkData> talkDatas = Load();
    public Dictionary<int, List<TalkData>> talks;
    public List<string> names = new List<string>();

    public void Init()
    {
        foreach (var name in names) 
        {
            var list = talkDatas.FindAll(x => x.Tag == name);
            talks.Add(name.GetHashCode(), list);
        }
    }

    static List<TalkData> Load()
    {
        string path = Application.dataPath + @"\Data\TalkData.json";

        if (File.Exists(path) == false) // 파일이 존재하는지 체크
        {
            Debug.Log("talkData Load Faill");
            return null;
        }
        StreamReader file = File.OpenText(path);
        if (file != null)
        {
            string json = JsonUtility.ToJson(file);
            return JsonUtility.FromJson<List<TalkData>>(json);
        }

        return null;
    }
}
