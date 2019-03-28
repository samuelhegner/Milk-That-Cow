using System.Collections.Generic;
using UnityEngine;

public class MilkBucket : MonoBehaviour
{
    public int bucketCapacity = 40;
    private int count;
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
        //for (var i = 0; i < milkList.Count; i++)
        //{
        //    GameObject obj = milkList[i];
        //    milkList.Remove(obj);

        //    if (obj)
        //    obj.GetComponent<MetaballParticleClass>().Destroy();
        //}

        for (var i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.GetComponent<Collider2D>()) child.GetComponent<Collider2D>().enabled = value;
        }
    }
}