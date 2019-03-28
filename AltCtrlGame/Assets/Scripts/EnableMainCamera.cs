using System.Collections;
using UnityEngine;

public class EnableMainCamera : MonoBehaviour
{
    public static bool IntroPlayed = false;

    public AudioManager AM;
    private bool cameraNotActivated = true;
    public GameObject introCamera;
    public float IntroTime;
    public GameObject MainCameras;

    public float OutroTime;


    private void Start()
    {
        if (IntroPlayed)
        {
            GetComponent<AudioSource>().enabled = false;
            IntroTime = 0;
        }

        StartCoroutine(EnableMainCameras());
        Crowd_Changer.ChangeState(1, Audience_Member.ViewerState.cheering, 1f);
        Crowd_Changer.ChangeState(2, Audience_Member.ViewerState.cheering, 1f);
        Text_Manager.CreateText(GameObject.Find("Main Camera").GetComponent<Camera>(), 8f, 0,
            new[] {"Milk!", "That!", "Cow!"}, 3f);
        StartCoroutine(MilkThatCow());
    }

    // Update is called once per frame
    private void Update()
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
            AM.Play("BGMusic");
        }
    }

    public IEnumerator MilkThatCow()
    {
        yield return new WaitForSeconds(OutroTime);
        Text_Manager.CreateText(GameObject.Find("Main Camera").GetComponent<Camera>(), 8f, 0,
            new[] {"Milk!", "That!", "Cow!"}, 3f);
        IntroPlayed = true;
    }
}