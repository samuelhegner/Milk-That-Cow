using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTester : MonoBehaviour
{
    int keep = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TryText", 2f);
        InvokeRepeating("TryCrowd", 2f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TryText() {
        Text_Manager.CreateText(GameObject.Find("Camera 1").GetComponent<Camera>(), 5, 0, new string[] { "Milk!", "That!", "Cow!" });
    }
    void TryCrowd() {
        if (keep == 0)
        {
            Crowd_Changer.ChangeState(1, Audience_Member.ViewerState.cheering, 0f);
            keep++;
        }
        else {
            Crowd_Changer.ChangeState(1, Audience_Member.ViewerState.idle, 1f);
            keep--;
        }
    }
}
