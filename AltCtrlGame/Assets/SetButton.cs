using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SetButton : NetworkBehaviour
{
    [SyncVar]
    GameObject testCube;
    void Start()
    {
        testCube = GameObject.Find("Test Cube");
    }

    
    public void Switch() {
        if(isLocalPlayer)
        testCube.SendMessage("SwitchCol");
    }
}
