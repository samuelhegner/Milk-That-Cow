using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket_Balance : MonoBehaviour
{
    public float force;

    Rigidbody rb;

    float randomNoiseStartX;
    float randomNoiseStartY;

    float noiseScroller = 0;
    public float noiseInc;

    public float randomForce;

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
        AddRandomForce();
        AddForce();
    }

    void AddForce() {
        float hAxis = Input.GetAxis("Horizontal");
        Vector3 forceVector = transform.TransformPoint(new Vector3(hAxis * force, 0, 0));

        rb.AddForce(forceVector, ForceMode.Force);
    }

    void AddRandomForce() {
        float noiseValue = Mathf.PerlinNoise(randomNoiseStartX + noiseScroller, randomNoiseStartY) * 2 - 1;

        print(noiseValue);

        Vector3 forceVector = transform.TransformPoint(new Vector3(noiseValue * randomForce, 0, 0));
        rb.AddForce(forceVector, ForceMode.Force);
    }
}
