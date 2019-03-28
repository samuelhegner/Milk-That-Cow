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

    public float shrinkSpeed;

    bool shrink = false;

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

        

        timerText.text = Mathf.FloorToInt(timer).ToString();

        if (timer <= 0)
        {
            GameIsActive = false;
            SceneManager.LoadScene(sceneToLoad);
        }
        else {
            timer -= Time.deltaTime;
        }

        if (timer < 11f) {
            last10Seconds();
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
        
    }

    public static float Map(float a, float b, float c, float d, float e)
    {
        float cb = c - b;
        float de = e - d;
        float howFar = (a - b) / cb;
        return d + howFar * de;
    }

    void last10Seconds() {
        Vector3 newScale = timerText.transform.localScale;

        timerText.color = Color.Lerp(timerText.color, Color.red, 0.25f * Time.deltaTime);

        if (shrink)
        {
            newScale.x -= Time.deltaTime * shrinkSpeed;
            newScale.y -= Time.deltaTime * shrinkSpeed;

            if (newScale.x < 1f)
            {
                shrink = false;
            }
        }
        else {
            newScale.x += Time.deltaTime * shrinkSpeed;
            newScale.y += Time.deltaTime * shrinkSpeed;

            if (newScale.x > 3f) {
                shrink = true;
            }
        }

        timerText.transform.localScale = newScale;

    }
}
