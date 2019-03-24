using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WinnerEffects : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private EffectData[] effectData;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayWinnerEffects();
    }

    void PlayWinnerEffects()
    {
        ScoreData[] scoreData = ScoreManager.GetScoreData();
        ScoreData winningTeam = scoreData[0];

        for (int i = 0; i < scoreData.Length; i++)
        {
            if (scoreData[i].milkProduced >= winningTeam.milkProduced)
            {
                winningTeam = scoreData[i];
            }
        }

        for (int i = 0; i < effectData.Length; i++)
        {
            if (winningTeam.teamTag == effectData[i].teamTag)
            {
                audioSource.PlayOneShot(effectData[i].clip);
            }
        }

    }

    [Serializable]
    private struct EffectData
    {
        public string teamTag;
        public AudioClip clip;
    }
}
