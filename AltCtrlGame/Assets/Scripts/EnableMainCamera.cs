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
        Crowd_Changer.ChangeState(1, Audience_Member.ViewerState.cheering, 1f);
        Crowd_Changer.ChangeState(2, Audience_Member.ViewerState.cheering, 1f);
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
            Crowd_Changer.ChangeState(1, Audience_Member.ViewerState.idle, 1f);
            Crowd_Changer.ChangeState(2, Audience_Member.ViewerState.idle, 1f);
            Game_Manager.StartGame();
        }

    }
}
