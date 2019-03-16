using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    { 
        if (col.GetComponent<MetaballParticleClass>())
        {
            col.GetComponent<MetaballParticleClass>().LifeTime = 0;
        }
    }
}
