using System.Collections.Generic;
using UnityEngine;

public class MilkCollision : MonoBehaviour
{
    private static List<GameObject> MilkColliders;
    public bool DontRegisterParticle = false;

    private void Awake()
    {
        MilkColliders = new List<GameObject>();
    }

    private void Start()
    {
        if (!DontRegisterParticle) MilkColliders.Add(gameObject);
    }

    private int count;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(gameObject.tag) && col.GetComponent<MetaballParticleClass>())
        {
            col.GetComponent<MetaballParticleClass>().IsInfinite = true;
            col.GetComponent<MetaballParticleClass>().witinTarget = true;
            count++;
            Debug.Log(count);
            if (DontRegisterParticle)
            {
                col.GetComponent<MetaballParticleClass>().SetTrailRenderer = false;
                col.gameObject.transform.SetParent(transform);
                
                return;
            }
            col.GetComponent<MetaballParticleClass>().SetTrailRenderer = false;
            col.gameObject.transform.SetParent(transform);

            transform.parent.gameObject.GetComponent<MilkBucket>().UpdateBucket(true, col.gameObject);

            ScoreManager.UpdateScoreData(col.tag, ScoreType.milkCaughtInBucket, 1);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(gameObject.tag) && col.GetComponent<MetaballParticleClass>().witinTarget)
        {
            col.GetComponent<MetaballParticleClass>().IsInfinite = false;
            col.GetComponent<MetaballParticleClass>().witinTarget = false;

            count--;

            if (DontRegisterParticle)
            {
                col.gameObject.transform.parent = null;
                col.GetComponent<MetaballParticleClass>().SetTrailRenderer = true;
               
                return;
            }

            transform.parent.gameObject.GetComponent<MilkBucket>().UpdateBucket(false, col.gameObject);
        }
    }
}