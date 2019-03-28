using System.Collections.Generic;
using UnityEngine;

public class MilkCollision : MonoBehaviour
{
    private static List<GameObject> MilkColliders;
    public bool DontRegisterParticle = false;
    private MilkBucket milkBucket;
    public GameObject collider;
    private void Awake()
    {
        MilkColliders = new List<GameObject>();
        milkBucket = transform.parent.GetComponent<MilkBucket>();
    }

    private void Start()
    {
        if (!DontRegisterParticle) MilkColliders.Add(gameObject);
    }

    void Update()
    {

        if (collider == null)
        {
            Debug.Log("Collider is null");
            return;
        }
        if (milkBucket.CheckIfFull())
        {
            collider.SetActive(false);
        }
        else
        {
            collider.SetActive(true);
        }
    }

    //private int count;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(gameObject.tag) && col.GetComponent<MetaballParticleClass>())
        {
            //col.GetComponent<MetaballParticleClass>().IsInfinite = true;
            //col.GetComponent<MetaballParticleClass>().witinTarget = true;
            //count++;
            //Debug.Log(count);
            //if (DontRegisterParticle)
            //{
            //    col.GetComponent<MetaballParticleClass>().SetTrailRenderer = false;
            //    col.gameObject.transform.SetParent(transform);

            //    return;
            //}
            //col.GetComponent<MetaballParticleClass>().SetTrailRenderer = false;
            //col.gameObject.transform.SetParent(transform);
            //col.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            transform.parent.gameObject.GetComponent<MilkBucket>().UpdateBucket(true);

            //count++;
            col.GetComponent<MetaballParticleClass>().Destroy();
            ScoreManager.UpdateScoreData(col.tag, ScoreType.milkCaughtInBucket, 1);
        }
    }

    //private void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.CompareTag(gameObject.tag) && col.GetComponent<MetaballParticleClass>().witinTarget)
    //    {
    //        col.GetComponent<MetaballParticleClass>().IsInfinite = false;
    //        col.GetComponent<MetaballParticleClass>().witinTarget = false;

    //        count--;

    //        if (DontRegisterParticle)
    //        {
    //            col.gameObject.transform.parent = null;
    //            col.GetComponent<MetaballParticleClass>().SetTrailRenderer = true;
               
    //            return;
    //        }
    //        col.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    //        transform.parent.gameObject.GetComponent<MilkBucket>().UpdateBucket(false, col.gameObject);
    //    }
    //}
}