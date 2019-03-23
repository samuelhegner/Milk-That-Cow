using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private UIFields data;

    void Start()
    {
        SetText(data);
        StartCoroutine(reLoad());
    }

    private IEnumerator reLoad()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }

    private void SetText(UIFields data)
    {
        ScoreData scoreData = ScoreManager.GetScoreData(data.teamTag);
        data.teamNameText.text = data.teamName;
        data.bucketsDrankText.text = "Buckets drank " + scoreData.bucketsDrank.ToString();
        data.milkSpiltText.text = "Milk split " + scoreData.milkSplit.ToString();
        data.milkProducedText.text = "Milk produced " + scoreData.milkProduced.ToString();
        data.milkCaughtInBucketText.text = "Milk caught " + scoreData.milkCaughtInBucket.ToString();
        data.totalScoreText.text = "Total score " + scoreData.totalScore.ToString();
    }

    [Serializable]
    private struct UIFields
    {
        public string teamTag;
        public string teamName;
        public Text teamNameText;
        public Text bucketsDrankText;
        public Text milkSpiltText;
        public Text milkProducedText;
        public Text milkCaughtInBucketText;
        public Text totalScoreText;
    } 
}
