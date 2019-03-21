using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket_Chug : MonoBehaviour
{
    public string InputAxis;

    public float chugDuration;

    HingeJoint joint;
    Bucket_Balance bal;
    Animator anim;

    public Vector3 startPos;

    public bool fullBucket;

    bool chugging;

    

    // Start is called before the first frame update
    private void Awake()
    {
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
        if (fullBucket) {
            if (Input.GetAxis("Vertical") < -0.8f && !chugging) {
                StartCoroutine(ChugBucket());
            }
        }
    }

    IEnumerator ChugBucket() {
        chugging = true;
        bal.enabled = false;
        while (Vector3.Distance(transform.position, startPos) > 0.1f) {
            joint.useSpring = true;

            yield return new WaitForEndOfFrame();
        }
        anim.Play("Chug");

        anim.enabled = true;

        yield return new WaitForSeconds(chugDuration);
        anim.SetTrigger("Return");
        yield return new WaitForSeconds(2f);

        anim.enabled = false;
        bal.enabled = true;
        joint.useSpring = false;
        chugging = false;
        fullBucket = false;
    }
}
