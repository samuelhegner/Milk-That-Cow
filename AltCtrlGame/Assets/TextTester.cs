using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TryText", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TryText() {
        Text_Manager.CreateText(GameObject.Find("Camera 1").GetComponent<Camera>(), 2, 2, new string[] { "testing 1", "testing 2", "testing 3" });
    }
}
