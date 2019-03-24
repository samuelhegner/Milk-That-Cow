using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMainCamera : MonoBehaviour
{
    public float IntroTime;
    public GameObject MainCameras;
    public GameObject introCamera;
    private bool cameraNotActivated = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnableMainCameras());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator EnableMainCameras()
    {
        while (cameraNotActivated)
        {
            yield return new WaitForSeconds(IntroTime);

            MainCameras.SetActive(true);
            introCamera.SetActive(false);
            cameraNotActivated = false;

            Game_Manager.StartGame();
        }

    }
}
