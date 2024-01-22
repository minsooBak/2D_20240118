using System;
using TMPro;
using UnityEngine;
public class PlayerTime : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = DateTime.Now.ToString("HH:mm");
    }
}
