using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LeaderBoardManager : MonoBehaviour
{
    [SerializeField] private GameObject leaderBoardItem;
    [SerializeField] private Transform container;
    [SerializeField] private TMP_Dropdown dropDown;
    private void OnEnable()
    {
        RefreshLeaderBoard();
    }

    public void RefreshLeaderBoard()
    {
        AuthManager.instance.RefreshLeaderBoard(dropDown.value, container, leaderBoardItem);
    }
}
