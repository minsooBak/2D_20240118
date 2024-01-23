using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

[CreateAssetMenu]
public class TalkDatas : ScriptableObject
{
    public struct sTalk
    {
        public string Tag;
        public string Name;
        public string Talk;
    }
    public Dictionary<int, List<sTalk>> talks = new();
    public List<string> names = new();

    public void Init()
    {
        List<sTalk> talkDatas = Load();
        foreach (var name in names) 
        {
            var list = talkDatas.FindAll(x => x.Tag == name);
            talks.Add(name.GetHashCode(), list);
        }
    }

    List<sTalk> Load()
    {
        string path = Application.dataPath + @"\Data\TalkData.json";

        if (File.Exists(path) == false) // 파일이 존재하는지 체크
        {
            Debug.Log("talkData Load Faill");
            return null;
        }
        string json = File.ReadAllText(path);
        //var data = CreateInstance("TalkData");
        return JsonConvert.DeserializeObject<List<sTalk>>(json);
    }
}
