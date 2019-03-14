using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise_Value_Tester : MonoBehaviour
{

    float noiseScroller = 0;
    public float noiseInc = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        noiseScroller += noiseInc * Time.deltaTime;
        float noiseValue = Mathf.PerlinNoise(0 + noiseScroller, 0) * 2 - 1;

        transform.position = new Vector3(8, noiseValue, 0);
    }
}
