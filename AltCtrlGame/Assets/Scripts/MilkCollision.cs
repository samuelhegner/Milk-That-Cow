using System.Collections.Generic;
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
            Debug.LogWarning(gameObject.name + " is not tagged with a team tag");
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
                Debug.Log("ParentChanged");
                return;
            }
            Debug.Log("Milk detected add score " + col.tag);
            milkSystem.AddOrRemoveMilk(gameObject.tag, true);


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
            Debug.Log("Milk leaving remove score");
            milkSystem.AddOrRemoveMilk(gameObject.tag, false);


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