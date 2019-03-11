using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class MatchStetup : MonoBehaviour
{

    void Awake()
    {
        FindInternetMatch("default");
    }
    //call this method to request a match to be created on the server
    public void CreateInternetMatch(string matchName)
    {
        NetworkManager.singleton.matchMaker.CreateMatch(matchName, 4, true, "", "", "", 0, 0, OnMatchCreate);
    }
    //Create Match success calback
    void OnMatchCreate(bool success, string info, MatchInfo matchInfoData)
    {
        if (success && matchInfoData != null)
        {
            NetworkServer.Listen(matchInfoData, 7777);
            //Start Host
            NetworkManager.singleton.StartHost(matchInfoData);
        }
        else
        {
            Debug.LogError("Create match failed : " + success + ", " + info);
        }
    }
    //call this method to find a match through the matchmaker
    public void FindInternetMatch(string matchName)
    {
        NetworkManager.singleton.matchMaker.ListMatches(0, 20, matchName, false, 0, 0, OnMatchListFound);
    }
    void OnMatchListFound(bool success, string info, List<MatchInfoSnapshot> matchInfoSnapshotLst)
    {
        if (success)
        {
            if (matchInfoSnapshotLst.Count != 0)
            {
                //Debug.Log("A list of matches was returned");
                //join the last server (just in case there are two...)
                NetworkManager.singleton.matchMaker.JoinMatch(matchInfoSnapshotLst[0].networkId, "", "", "", 0, 0, OnjoinedMatch);
            }
            else
            {
                Debug.Log("No matches in requested room!");
                CreateInternetMatch("default");
            }
        }
        else
        {
            Debug.LogError("Couldn't connect to match maker");
        }
    }
    void OnjoinedMatch(bool success, string info, MatchInfo matchInfoData)
    {
        if (success)
        {
            //Debug.Log("Able to join a match");
            NetworkManager.singleton.StartClient(matchInfoData);
        }
        else
        {
            Debug.LogError("Join match failed");
        }
    }
}
