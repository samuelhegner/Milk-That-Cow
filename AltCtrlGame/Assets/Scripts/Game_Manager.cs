using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public float totalTime;

    public string sceneToLoad;

    public TextMeshProUGUI timerText;

    float timer;

    public static bool GameIsActive = false;

    public GameObject[] gameElements;
    void Start()
    {
        timer = totalTime;
        ChangeObjectState(false);
    }

    void Update()
    {
        if (!GameIsActive)
        {
            return;
        }

        ChangeObjectState(true);

        timer -= Time.deltaTime;

        timerText.text = Mathf.FloorToInt(timer).ToString();

        if (timer <= 0)
        {
            GameIsActive = false;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void ChangeObjectState(bool state)
    {
        for (int i = 0; i < gameElements.Length; i++)
        {
            gameElements[i].SetActive(state);
        }
    }

    public static void StartGame()
    {
        GameIsActive = true;
        Crowd_Changer.ChangeState(1, Audience_Member.ViewerState.idle, 1f);
        Crowd_Changer.ChangeState(2, Audience_Member.ViewerState.idle, 1f);
    }

    public static float Map(float a, float b, float c, float d, float e)
    {
        float cb = c - b;
        float de = e - d;
        float howFar = (a - b) / cb;
        return d + howFar * de;
    }
}
