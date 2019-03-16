using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SwitchColour : NetworkBehaviour
{
    Renderer rend;

    public bool col;

    [SyncVar]
    Color colour;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        rend.material.color = colour;
        if (col)
        {
            colour = Color.red;
        }
        else {
            colour = Color.blue;
        }


    }

    [Command]
    void Cmd_ProvideColorToServer(Color c)
    {

        colour = c;
    }

    [ClientCallback]
    void TransmitColor()
    {
        if (isLocalPlayer)
        {
            Cmd_ProvideColorToServer(colour);
        }
    }

    public void SwitchCol() {
        col = !col;
    }
}
