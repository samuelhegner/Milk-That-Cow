using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket_Balance : MonoBehaviour
{
    public float force;

    public float randomForce;
    public float noiseScale;


    Rigidbody rb;

    float randomNoiseStartX;
    float randomNoiseStartY;

    float noiseScroller = 0;
    public float noiseInc;

    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        randomNoiseStartX = Random.Range(-1000, 1000);
        randomNoiseStartY = Random.Range(-1000, 1000);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        noiseScroller += noiseInc;
        print((Mathf.PerlinNoise(randomNoiseStartX + noiseScroller, randomNoiseStartY) * 2f) - 1f);
        AddRandomForce((Mathf.PerlinNoise(randomNoiseStartX + noiseScroller, randomNoiseStartY) * 2f) - 1f);
        AddForce();
    }

    void AddForce() {
        float hAxis = Input.GetAxis("Horizontal");
        Vector3 forceVector = transform.TransformPoint(new Vector3(hAxis * force, 0, 0));

        rb.AddForce(forceVector, ForceMode.Acceleration);
    }

    void AddRandomForce(float NoiseVal)
    {
        NoiseVal *= noiseScale;
        Vector3 forceVector = transform.TransformPoint(new Vector3(NoiseVal * randomForce, 0, 0));
        rb.AddForce(forceVector, ForceMode.Acceleration);
    }
}
