using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerMover : NetworkBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private void Update()
    {

        if (isLocalPlayer) {
            float h = Input.acceleration.x;
            float v = Input.acceleration.z;

            Vector3 movement = new Vector3(h, 0f, v);
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
        

    }
}
