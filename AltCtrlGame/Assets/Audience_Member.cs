using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience_Member : MonoBehaviour
{
    
    public enum ViewerState {
        idle,
        cheering,
        chugging,
        chanting
    }

    public ViewerState currentState;

    Vector3 idlePos;
    Vector3 cheerPos;
    // Start is called before the first frame update
    void Start()
    {
        idlePos = transform.position;
        cheerPos = transform.position;
        cheerPos.y += 5f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState) {
            case ViewerState.idle:
                Idle();
                break;
            case ViewerState.chanting:
                Chanting();
                break;
            case ViewerState.chugging:
                Chugging();
                break;
            case ViewerState.cheering:
                Cheering();
                break;
        }
    }

    void Idle() {
        transform.position = Vector3.Lerp(transform.position, idlePos, Time.deltaTime);
    }

    void Cheering() {
        transform.position = Vector3.Lerp(transform.position, cheerPos, Time.deltaTime);
    }

    void Chugging() {

    }

    void Chanting() {

    }

    public IEnumerator ChangeState(ViewerState nextState, float maxDelay) {
        yield return new WaitForSeconds(Random.Range(0, maxDelay));
        currentState = nextState;
    }

}
