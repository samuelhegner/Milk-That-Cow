using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{

    public string pipeName;

    public ParticleSystem ps;

    ParticleSystem.EmissionModule emission;

    // Start is called before the first frame update
    void Start()
    {
        emission = ps.emission;
    }

    public void Flip(string nameCheck) {

        if(nameCheck == pipeName)
        emission.enabled = !emission.enabled;
    }
}
