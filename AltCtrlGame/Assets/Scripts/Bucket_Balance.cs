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
        randomNoiseStartX = Random.Range(-10000, 10000);
        randomNoiseStartY = Random.Range(-10000, 10000);
    }

    void FixedUpdate()
    {
        //maximum force possible
        maxForce = force + (randomForce * noiseScale);

        // moves noise 2d coordinate for next fixed frame
        noiseScroller += noiseInc;

        //calculates the force to add this frame.
        Vector3 totalForce = AddRandomForce(((Mathf.PerlinNoise(randomNoiseStartX + noiseScroller, randomNoiseStartY + noiseScroller) * 2f) - 1f)) + AddForce();

        //adds the force to the rb
        rb.AddForce(totalForce, ForceMode.Force);

        //clamps maxspeed
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        //set the force visualizer
        SetTiltOmeter((((Mathf.PerlinNoise(randomNoiseStartX + noiseScroller, randomNoiseStartY + noiseScroller) * 2f) - 1f) * noiseScale * randomForce) + (Input.GetAxis("Horizontal") * force));
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
        //maps the forces input onto a -89 to 89 degree rotation and sets the arrows rotation to it
        float zRot = Game_Manager.Map(forceInput, -maxForce, maxForce, 89f, -89f);
        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, zRot));
    }
}
