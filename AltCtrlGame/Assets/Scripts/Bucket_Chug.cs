using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket_Chug : MonoBehaviour
{
    public string InputAxis;

    public float chugDuration;

    HingeJoint joint;
    Rigidbody rb;
    Bucket_Balance bal;
    Animator anim;
    public MilkBucket bucket;

    public Vector3 startPos;

    public bool fullBucket;

    bool chugging;

    

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bal = GetComponent<Bucket_Balance>();
        joint = GetComponent<HingeJoint>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        fullBucket = bucket.CheckIfFull();
        if (fullBucket) {
            if (InputAxis != "")
            {
                if (Input.GetAxis(InputAxis) < -0.8f && !chugging)
                {
                    StartCoroutine(ChugBucket());
                }
            }
            else {
                if (Input.GetAxis("Vertical") < -0.8f && !chugging)
                {
                    StartCoroutine(ChugBucket());
                }
            }
            
        }
    }

    IEnumerator ChugBucket() {
        chugging = true;
        bucket.EnableOrDisableColliders(false);
        bal.enabled = false;
        while (Vector3.Distance(transform.position, startPos) > 0.1f) {
            joint.useSpring = true;

            yield return new WaitForEndOfFrame();
        }
        rb.isKinematic = true;
        anim.Play("Chug");

        anim.enabled = true;

        yield return new WaitForSeconds(chugDuration);
        anim.SetTrigger("Return");
        yield return new WaitForSeconds(2f);

        anim.enabled = false;
        bal.enabled = true;
        joint.useSpring = false;
        rb.isKinematic = false;

        chugging = false;
        fullBucket = false;
        bucket.EnableOrDisableColliders(true);
    }
}
