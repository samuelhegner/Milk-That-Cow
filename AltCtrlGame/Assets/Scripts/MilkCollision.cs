﻿using System.Collections.Generic;
using UnityEngine;

public class MilkCollision : MonoBehaviour
{
    private MilkSystem milkSystem;
    public bool DontRegisterParticle = false;


    private static List<GameObject> MilkColliders;

    private void Awake()
    {
        MilkColliders = new List<GameObject>();
    }

    private void Start()
    {
        milkSystem = GameObject.FindGameObjectWithTag("MilkManager").GetComponent<MilkSystem>();
        if (gameObject.CompareTag("Untagged"))
        {
            //Debug.LogWarning(gameObject.name + " is not tagged with a team tag");
        }

        if (!DontRegisterParticle)
        {
            MilkColliders.Add(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(gameObject.tag) && col.GetComponent<MetaballParticleClass>())
        {
            col.GetComponent<MetaballParticleClass>().IsInfinite = true;
            col.GetComponent<MetaballParticleClass>().witinTarget = true;
            if (DontRegisterParticle)
            {
                col.GetComponent<MetaballParticleClass>().SetTrailRenderer = false;
                col.gameObject.transform.SetParent(transform);
                //Debug.Log("ParentChanged");
                return;
            }

            transform.parent.gameObject.GetComponent<MilkBucket>().UpdateBucket(true, col.gameObject);
            
            //milkSystem.AddOrRemoveMilk(gameObject.tag, true);
            ScoreManager.UpdateScoreData(col.tag, ScoreType.milkCaughtInBucket, 1);

            //Debug.Log("Produced " + ScoreManager.scoreDataArray[1].milkProduced + " Split " + ScoreManager.scoreDataArray[1].milkSplit + " Caught in bucket " + ScoreManager.scoreDataArray[1].milkCaughtInBucket);


            //col.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
        else
        {
            //Destroy(col.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(gameObject.tag) && col.GetComponent<MetaballParticleClass>().witinTarget)
        {
            col.GetComponent<MetaballParticleClass>().IsInfinite = false;
            col.GetComponent<MetaballParticleClass>().witinTarget = false;


            if (DontRegisterParticle)
            {
                col.gameObject.transform.parent = null;
                col.GetComponent<MetaballParticleClass>().SetTrailRenderer = true;
                return;
            }

            
            //milkSystem.AddOrRemoveMilk(gameObject.tag, false);


            transform.parent.gameObject.GetComponent<MilkBucket>().UpdateBucket(false, col.gameObject);


            //col.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        }
    }


    public static GameObject DisableBucket(string teamTag)
    {
        GameObject objToReturn = null;
        foreach (var obj in MilkColliders)
        {
            if (obj.tag == teamTag)
            {
                obj.SetActive(false);
                objToReturn = obj;
            }
        }

        return objToReturn;
    }

}