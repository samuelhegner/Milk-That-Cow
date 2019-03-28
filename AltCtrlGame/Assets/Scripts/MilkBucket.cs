using System.Collections.Generic;
using UnityEngine;

public class MilkBucket : MonoBehaviour
{
    public int bucketCapacity = 40;
    public int count;
    //private List<GameObject> milkList = new List<GameObject>();

    public void UpdateBucket(bool state)
    {
        if (state)
        {
            count++;
        }
        else
        {
            count--;
        }
    }

    public bool CheckIfFull()
    {
        return count >= bucketCapacity;
    }

    public void BucketChug(bool value)
    {
        count = 0;

        for (var i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.GetComponent<Collider2D>()) child.GetComponent<Collider2D>().enabled = value;
        }
    }
}