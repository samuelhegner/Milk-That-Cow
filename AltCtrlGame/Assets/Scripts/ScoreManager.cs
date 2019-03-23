﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    //public static ScoreManager instance = null;
    public static ScoreData[] scoreDataArray = new ScoreData[2];

    //public void Awake()
    //{
    //    if (instance == null)
    //    {
            
    //        instance = this;
    //        DontDestroyOnLoad(this);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public static void RegisterTeam(string teamTag, int index)
    {
        scoreDataArray[index] = new ScoreData(teamTag);
    }

    //public static void UpdateScoreData(ScoreData scoreData)
    //{
    //    for (int i = 0; i < scoreDataArray.Length; i++)
    //    {
    //        if (scoreDataArray[i].teamTag == scoreData.teamTag)
    //        {
    //            scoreDataArray[i] = scoreData;
    //        }
    //    }
    //}

    public static ScoreData GetScoreData(string teamTag)
    {
        for (int i = 0; i < scoreDataArray.Length; i++)
        {
            if (scoreDataArray[i].teamTag == teamTag)
            {
                return scoreDataArray[i];
            }
        }
        Debug.LogError("No valid Score data found");
        return new ScoreData("");
    }


    public static void UpdateScoreData(string teamTag, ScoreType scoreToUpdate, float amount = 1)
    {
        for (int i = 0; i < scoreDataArray.Length; i++)
        {
            if (scoreDataArray[i].teamTag != teamTag)
            {
                continue;
            }

            if (scoreToUpdate == ScoreType.bucketsDrank)
            {
                scoreDataArray[i].bucketsDrank += (int)amount;
            }

            if (scoreToUpdate == ScoreType.milkSplit)
            {
                scoreDataArray[i].milkSplit += (int) amount;
            }

            if (scoreToUpdate == ScoreType.milkCaughtInBucket)
            {
                scoreDataArray[i].milkCaughtInBucket += (int) amount;
            }

            if (scoreToUpdate == ScoreType.milkProduced)
            {
                scoreDataArray[i].milkProduced += (int) amount;
            }

            if (scoreToUpdate == ScoreType.totalScore)
            {
                scoreDataArray[i].totalScore = amount;
            }
        }
    }
    
}
[Serializable]
public struct ScoreData
{
    [HideInInspector] public string teamTag;
    public int bucketsDrank;
    public int milkSplit;
    public int milkProduced;
    public int milkCaughtInBucket;
    public float totalScore;

    public ScoreData(string teamTag)
    {
        this.teamTag = teamTag;
        bucketsDrank = 0;
        milkSplit = 0;
        milkCaughtInBucket = 0;
        milkProduced = 0;
        totalScore = 0;
    }
}

public enum ScoreType
{
    bucketsDrank,
    milkSplit,
    milkCaughtInBucket,
    milkProduced,
    totalScore
}

