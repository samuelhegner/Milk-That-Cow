﻿using System.Collections.Generic;
using UnityEngine;

public class MilkBucket : MonoBehaviour
{
    private readonly int bucketCapacity = 24;
    private int count;
    private List<GameObject> milkList = new List<GameObject>();

    public void UpdateBucket(bool state, GameObject obj)
    {
        if (state)
        {
            count++;
            milkList.Add(obj);
        }
        else
        {
            count--;
            if (milkList.Contains(obj))
                milkList.Remove(obj);
        }
    }

    public bool CheckIfFull()
    {
        return count >= bucketCapacity;
    }

    public void BucketChug(bool value)
    {
        for (int i = 0; i < milkList.Count; i++)
        {
            milkList[i].GetComponent<MetaballParticleClass>().Destroy();
            milkList.Remove(milkList[i]);
        }

        for (var i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.GetComponent<Collider2D>()) child.GetComponent<Collider2D>().enabled = value;
        }
    }
}