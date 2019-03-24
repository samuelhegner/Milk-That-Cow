using System;
using UnityEngine;

public class WinnerEffects : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private EffectData[] effectData;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayWinnerEffects();
    }

    private void PlayWinnerEffects()
    {
        var scoreData = ScoreManager.GetScoreData();
        var winningTeam = scoreData[0];

        for (var i = 0; i < scoreData.Length; i++)
            if (scoreData[i].milkProduced >= winningTeam.milkProduced)
                winningTeam = scoreData[i];

        for (var i = 0; i < effectData.Length; i++)
            if (winningTeam.teamTag == effectData[i].teamTag)
                audioSource.PlayOneShot(effectData[i].clip);
    }

    [Serializable]
    private struct EffectData
    {
        public string teamTag;
        public AudioClip clip;
    }
}