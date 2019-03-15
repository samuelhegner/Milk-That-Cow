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

    public RectTransform arrow;

    public float maxForce = 0;

    public float maxSpeed;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        randomNoiseStartX = Random.Range(-1000, 1000);
        randomNoiseStartY = Random.Range(-1000, 1000);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        maxForce = force + (randomForce * noiseScale);
        noiseScroller += noiseInc;
        Vector3 totalForce = AddRandomForce((Mathf.PerlinNoise(randomNoiseStartX + noiseScroller, randomNoiseStartY + noiseScroller) * 2f) - 1f) + AddForce();
        rb.AddForce(totalForce, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        SetTiltOmeter((Input.GetAxis("Horizontal")* force) + ((Mathf.PerlinNoise(randomNoiseStartX + noiseScroller, randomNoiseStartY + noiseScroller) * 2f) - 1f)* noiseScale * randomForce);
    }

    Vector3 AddForce() {
        float hAxis = Input.GetAxis("Horizontal");
        Vector3 forceVector = transform.TransformPoint(new Vector3(hAxis * force, 0, 0));

        return forceVector;
    }

    Vector3 AddRandomForce(float NoiseVal)
    {
        NoiseVal *= noiseScale;
        Vector3 forceVector = transform.TransformPoint(new Vector3(NoiseVal * randomForce, 0, 0));
        return forceVector;
    }

    void SetTiltOmeter(float forceInput) {

        float zRot = Game_Manager.Map(forceInput, -maxForce, maxForce, 89f, -89f);
        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, zRot));
    }
}
