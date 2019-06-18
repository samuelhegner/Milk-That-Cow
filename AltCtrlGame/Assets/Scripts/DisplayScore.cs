using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private UIFields data;
    [SerializeField] private GameObject[] bucketImages;
    [SerializeField] [Range(0, 1)] private float fillSpeed;
    private void Start()
    {
        foreach (GameObject bucket in bucketImages)
        {
            bucket.GetComponent<BucketScoreUI>().ClearImage();
            bucket.gameObject.SetActive(false);
        }
        StartCoroutine(BucketFill());


        //SetText(data);
    }
    private IEnumerator BucketFill()
    {
        ScoreData scoreData = ScoreManager.GetScoreData(data.teamTag);
        int bucketsDrank = scoreData.bucketsDrank;


        if (scoreData.teamTag == "NULL")
            bucketsDrank = Random.Range(3, 9);


        int index = 0;

        while (index < bucketsDrank)
        {
            BucketScoreUI bucket = bucketImages[index].GetComponent<BucketScoreUI>();
            bucketImages[index].SetActive(true);
            bucket.FillBucket(fillSpeed, index + 1);
            if (bucket.IsFull())
            {
                index++;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void SetText(UIFields data)
    {
        //ScoreData scoreData = ScoreManager.GetScoreData(data.teamTag);
        //scoreData.bucketsDrank = scoreData.bucketsDrank;
        ////Debug.Log(scoreData.milkSplit);
        ////Debug.Log(scoreData.milkProduced);
        //float milkSpilt = (scoreData.milkSplit / (float)scoreData.milkProduced) * 100;
        //float total = scoreData.bucketsDrank * (scoreData.milkProduced - scoreData.milkSplit);
        ////Debug.Log(total);
        //data.teamNameText.text = data.teamName;
        //data.bucketsDrankText.text = "Buckets drank " + scoreData.bucketsDrank;
        //data.milkSpiltText.text = "Milk split " + (int)milkSpilt + " %";
        ////data.milkProducedText.text = "Milk produced " + scoreData.milkProduced;
        ////data.milkCaughtInBucketText.text = "Milk caught " + scoreData.milkCaughtInBucket;
        //data.totalScoreText.text = "Total score " + total;
    }

    [Serializable]
    private struct UIFields
    {
        public string teamTag;
        public string teamName;
        //public Text teamNameText;
        //public Text bucketsDrankText;
        //public Text milkSpiltText;

        //public Text totalScoreText;
    }
}