using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowd_Changer : MonoBehaviour
{
    public Audience_Member[] audience1;

    public Audience_Member[] audience2;




    public static Crowd_Changer instance;

     
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        GameObject[] _audience1 = GameObject.FindGameObjectsWithTag("Audience1");
        GameObject[] _audience2 = GameObject.FindGameObjectsWithTag("Audience2");

        print(_audience1.Length);
        print(_audience2.Length);

        List<Audience_Member> temp1 = new List<Audience_Member>();
        List<Audience_Member> temp2 = new List<Audience_Member>();

        foreach (GameObject go in _audience1) {
            temp1.Add(go.GetComponent<Audience_Member>());
        }

        foreach (GameObject go in _audience2)
        {
            temp2.Add(go.GetComponent<Audience_Member>());
        }

        print(temp1.Count);
        print(temp2.Count);

        audience1 = temp1.ToArray();
        audience2 = temp2.ToArray();
    }

    /// <summary>
    /// Change the state of crowd 1 or 2
    /// </summary>
    /// <param name="audienceNumber"> Number 1 or 2 to select the crowd </param>
    /// <param name="state"> What crow state to switch to </param>
    /// <param name="delay"> Longest possible wait time for the switch </param>
    public static void ChangeState(int audienceNumber, Audience_Member.ViewerState state, float delay) {
        if (audienceNumber == 1)
        {
            foreach (Audience_Member member in instance.audience1)
            {
                member.StartCoroutine(member.ChangeState(state, delay));
            }
        }
        else if(audienceNumber == 2) {
            foreach (Audience_Member member in instance.audience2)
            {
                member.StartCoroutine(member.ChangeState(state, delay));
            }
        }
        
    }
}
