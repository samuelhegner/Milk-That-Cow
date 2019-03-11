using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkingTest : NetworkBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
       // NetworkManager.singleton.
    }

    // Update is called once per frame
    void Update()
    {
        if (!Data.ButtonPressed)
        {
            return;
        }
        if (GetComponent<MeshRenderer>())
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (GetComponent<Camera>())
        {
            GetComponent<Camera>().backgroundColor = Color.red;
        }
    }

    public void ChangeColor()
    {
        Data.ButtonPressed = true;
        Debug.Log("Button Pressed");
    }
}

public struct Data
{
    [SyncVar]
    public static bool ButtonPressed = false;
}
