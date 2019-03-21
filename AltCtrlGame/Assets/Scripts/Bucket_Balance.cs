using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket_Balance : MonoBehaviour
{
    [Header("Axis to use:")]
    [Tooltip("Set the Input Axis to be used (leave empty to default to to horizontal axis)")]
    public string InputAxis;
    [Tooltip("Force of player Input")]
    public float force;
    [Tooltip("Force of random noise (value should be lower than force)")]
    public float randomForce;
    [Tooltip("Scales the noise")]
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
        float hAxis;

        //Sets the Input to custum axis or or defaults to horizontal axis
        if (InputAxis != ""){
            hAxis = Input.GetAxis(InputAxis);
        }else{
            hAxis = Input.GetAxis("Horizontal");
        }

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
        arrow.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, zRot)), Time.fixedDeltaTime * 15f);
    }
}
