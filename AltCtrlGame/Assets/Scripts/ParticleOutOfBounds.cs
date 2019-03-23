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
            col.GetComponent<MetaballParticleClass>().LifeTime = 0;
            col.GetComponent<MetaballParticleClass>().witinTarget = false;
            col.GetComponent<MetaballParticleClass>().IsInfinite = false;

            //if (col.CompareTag(milkSystem.team1TeamInfo.teamTag))
            //{
            //    milkSystem.team1TeamInfo.scoreData.milkSplit++;
            //}

            //if (col.CompareTag(milkSystem.team2TeamInfo.teamTag))
            //{
            //    milkSystem.team2TeamInfo.scoreData.milkSplit++;
            //}

            ScoreManager.UpdateScoreData(col.tag, ScoreType.milkSplit, 1);
        }
    }
}
