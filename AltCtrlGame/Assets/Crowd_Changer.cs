using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowd_Changer : MonoBehaviour
{
    public Audience_Member[] audience;

    public static Crowd_Changer instance;

     
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audience = GameObject.FindObjectsOfType<Audience_Member>();
    }

    public static void ChangeState(Audience_Member.ViewerState state) {
        foreach (Audience_Member member in instance.audience) {
            member.SendMessage("ChangeState", state);
        }
    }
}
