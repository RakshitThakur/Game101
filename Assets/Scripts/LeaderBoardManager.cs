using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardManager : MonoBehaviour
{
    [SerializeField] private GameObject leaderBoardItem;
    [SerializeField] private Transform container;
    private void OnEnable()
    {
       AuthManager.instance.RefreshLeaderBoard(container, leaderBoardItem);
    }
}
