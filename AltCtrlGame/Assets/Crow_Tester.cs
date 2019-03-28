using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow_Tester : MonoBehaviour
{
    int t1 = 0;
    int t2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TryCrowd", 2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TryCrowd()
    {
        int ran = Random.Range(0, 2);

        if (ran == 0)
        {
            if (t1 == 1)
            {
                Crowd_Changer.ChangeState(1, Audience_Member.ViewerState.idle, 1f);
                t1--;
                print("Crowd 1 idle");
            }
            else
            {
                Crowd_Changer.ChangeState(1, Audience_Member.ViewerState.cheering, 1f);
                t1++;
                print("Crowd 1 Cheer");
            }
            
        }
        else {
            if (t2 == 1)
            {
                Crowd_Changer.ChangeState(2, Audience_Member.ViewerState.idle, 1f);
                t2--;
                print("Crowd 2 idle");
            }
            else
            {
                Crowd_Changer.ChangeState(2, Audience_Member.ViewerState.cheering, 1f);
                t2++;
                print("Crowd 2 Cheer");
            }
        }
    }
}
