using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
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

    [Space]
    [Header("Audio stuff")]
    public AudioSource audioSource;
    public AudioClip chugClip;


    bool chugging;

    private string teamTag;
    private MilkSystem milkSystem;
    

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bal = GetComponent<Bucket_Balance>();
        joint = GetComponent<HingeJoint>();
        anim = GetComponent<Animator>();

        teamTag = gameObject.tag;
        milkSystem = GameObject.FindGameObjectWithTag("MilkManager").GetComponent<MilkSystem>();

        audioSource = GetComponent<AudioSource>();

        if (!chugClip)
        {
            Debug.LogError("No Chug Audio");
        }
        else
        {
            chugDuration = chugClip.length;
        }
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
                if (Input.GetKeyDown(KeyCode.Space) && !chugging)
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

        if (milkSystem.team1TeamInfo.teamTag == teamTag)
        {
            for (int i = 0; i < MilkSpawner.particleList.Count -1; i++)
            {
                if (MilkSpawner.particleList[i] == null)
                {
                    continue;
                }

                if (MilkSpawner.particleList[i].CompareTag(teamTag))
                {
                    MilkSpawner.particleList[i].GetComponent<SpriteRenderer>().enabled = false;
                    MilkSpawner.particleList[i].GetComponent<TrailRenderer>().enabled = false;
                    MilkSpawner.particleList[i].GetComponent<TrailRenderer>().Clear();
                }
            }
        }
        if (milkSystem.team2TeamInfo.teamTag == teamTag)
        {
            for (int i = 0; i < MilkSpawner.particleList.Count - 1; i++)
            {
                if (MilkSpawner.particleList[i] == null)
                {
                    continue;
                }

                if (MilkSpawner.particleList[i].CompareTag(teamTag))
                {
                    MilkSpawner.particleList[i].GetComponent<SpriteRenderer>().enabled = false;
                    MilkSpawner.particleList[i].GetComponent<TrailRenderer>().enabled = false;
                    MilkSpawner.particleList[i].GetComponent<TrailRenderer>().Clear();
                }
            }
        }
        if (chugClip)
            audioSource.PlayOneShot(chugClip);

        ScoreManager.UpdateScoreData(teamTag, ScoreType.bucketsDrank);
        chugging = true;
        bucket.BucketChug(false);
        bal.enabled = false;
        while (Vector3.Distance(transform.position, startPos) > 0.1f) {
            joint.useSpring = true;

            yield return new WaitForEndOfFrame();
        }

        if (teamTag == milkSystem.team2TeamInfo.teamTag)
        {
            Crowd_Changer.ChangeState(2, Audience_Member.ViewerState.cheering, 1);
        }
        else if(teamTag == milkSystem.team1TeamInfo.teamTag) {
            Crowd_Changer.ChangeState(1, Audience_Member.ViewerState.cheering, 1);
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

        if (teamTag == milkSystem.team2TeamInfo.teamTag)
        {
            Crowd_Changer.ChangeState(2, Audience_Member.ViewerState.idle, 1);
        }
        else if (teamTag == milkSystem.team1TeamInfo.teamTag)
        {
            Crowd_Changer.ChangeState(1, Audience_Member.ViewerState.idle, 1);
        }

        fullBucket = false;
        bucket.BucketChug(true);
    }
}
