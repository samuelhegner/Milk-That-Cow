using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private UIFields data;

    private void Start()
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
        var scoreData = ScoreManager.GetScoreData(data.teamTag);
        scoreData.bucketsDrank = Random.Range(1, 15);
        //Debug.Log(scoreData.milkSplit);
        //Debug.Log(scoreData.milkProduced);
        float milkSpilt = ((float)scoreData.milkSplit / (float)scoreData.milkProduced) * 100;
        float total = scoreData.bucketsDrank * (scoreData.milkProduced - scoreData.milkSplit);
        //Debug.Log(total);
        data.teamNameText.text = data.teamName;
        data.bucketsDrankText.text = "Buckets drank " + scoreData.bucketsDrank;
        data.milkSpiltText.text = "Milk split " + milkSpilt + " %";
        //data.milkProducedText.text = "Milk produced " + scoreData.milkProduced;
        //data.milkCaughtInBucketText.text = "Milk caught " + scoreData.milkCaughtInBucket;
        data.totalScoreText.text = "Total score " + total;
    }

    [Serializable]
    private struct UIFields
    {
        public string teamTag;
        public string teamName;
        public Text teamNameText;
        public Text bucketsDrankText;
        public Text milkSpiltText;
        //public Text milkProducedText;
        //public Text milkCaughtInBucketText;
        public Text totalScoreText;
    }
}