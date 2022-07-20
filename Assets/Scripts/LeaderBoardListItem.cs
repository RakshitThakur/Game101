using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public struct LeaderBoardItemData
{
    public string username;
    public int time;
}
public class LeaderBoardListItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI timeText;
    public void SetUp(LeaderBoardItemData item)
    {
        usernameText.text = item.username;
        timeText.text = item.time.ToString();
    }
}
