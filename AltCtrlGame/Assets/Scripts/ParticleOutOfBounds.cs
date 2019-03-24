using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOutOfBounds : MonoBehaviour
{
    //private MilkSystem milkSystem;

    //private void Awake()
    //{
    //    milkSystem = GameObject.FindGameObjectWithTag("MilkManager").GetComponent<MilkSystem>();
    //}

    private void OnTriggerEnter2D(Collider2D col)
    { 
        if (col.GetComponent<MetaballParticleClass>())
        {
            col.GetComponent<MetaballParticleClass>().Destroy();


            ScoreManager.UpdateScoreData(col.tag, ScoreType.milkSplit, 1);
        }
    }
}
