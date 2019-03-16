using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2D;

public class Core : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
		Water2D_Spawner.instance.Dynamic = true;
		Water2D_Spawner.instance.Spawn ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
