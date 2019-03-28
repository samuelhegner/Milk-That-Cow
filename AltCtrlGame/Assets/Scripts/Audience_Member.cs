using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Audience_Member : MonoBehaviour
{
    

    public Camera audienceCamera;
    public int ran;

    public bool multipleAnimations;
    
    public enum ViewerState {
        idle,
        cheering,
        chugging,
        chanting
    }

    public ViewerState currentState;

    Vector3 idlePos;
    Vector3 cheerPos;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        idlePos = transform.position;
        cheerPos = transform.position;
        cheerPos.y += 5f;
        anim = GetComponent<Animator>();

        if (anim.parameterCount > 2) {
            multipleAnimations = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState) {
            case ViewerState.idle:
                Idle();
                break;
            case ViewerState.cheering:
                Cheering();
                break;
        }

        /*if (currentState != ViewerState.idle)
        {
            audienceCamera.enabled = true;
        }*/
    }

    void Idle() {
        anim.SetBool("idle", true);
    }

    void Cheering() {
        if (multipleAnimations) {
            anim.SetInteger("ran", ran);
        }
        anim.SetBool("idle", false);
    }


    public IEnumerator ChangeState(ViewerState nextState, float maxDelay) {
        yield return new WaitForSeconds((float)Random.Range(0, maxDelay));
        currentState = nextState;
        ran = Random.Range(0, 2);
    }

}
