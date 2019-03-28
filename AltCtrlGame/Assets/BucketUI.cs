using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BucketUI : MonoBehaviour
{
    public Image img;
    public GameObject text;

    public MilkBucket milk;

    float currentAmount;
    float fullAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentAmount = milk.count;
        fullAmount = milk.bucketCapacity;

        img.fillAmount = currentAmount / fullAmount;

        if (img.fillAmount == 1f)
        {
            text.SetActive(true);
        }
        else {
            text.SetActive(false);
        }
    }
}
