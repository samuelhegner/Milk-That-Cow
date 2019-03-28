using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class ParticleCollisionTest : MonoBehaviour
{
    public int milkCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle Collision");
    }

    void OnTriggerEnter(Collider col)
    {
        //return;
        Debug.Log("Particle trigger" + col.name);
        //Destroy(col.gameObject);
        milkCount++;
        Debug.Log(milkCount);
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Particle Collision " + col.gameObject.name);
        Destroy(col.gameObject);
        milkCount++;
        Debug.Log(milkCount);
    }
}
