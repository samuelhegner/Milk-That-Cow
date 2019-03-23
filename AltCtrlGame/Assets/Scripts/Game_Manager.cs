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


    void Start()
    {
        timer = totalTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        timerText.text = Mathf.FloorToInt(timer).ToString();

        if (timer <= 0) {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public static float Map(float a, float b, float c, float d, float e)
    {
        float cb = c - b;
        float de = e - d;
        float howFar = (a - b) / cb;
        return d + howFar * de;
    }
}
