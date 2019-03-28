using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text_Manager : MonoBehaviour
{
    public static Text_Manager instance;

    bool busy;

    public static bool inProg;

    public Canvas canvas;

    public GameObject textPrefab;

    void Awake()
    {
        instance = this;

    }

    void Update()
    {
        
    }

    static public void CreateText(Camera cam, float lerpSpeed, float timeBetweenWords, string[] words, float delay)
    {
        if (instance.busy)
        {
            Debug.LogWarning("Another message is being displayed");
        }
        else {
            instance.StartCoroutine(instance.PlayWords(cam, lerpSpeed, timeBetweenWords, words, delay));
        }
    }

    public IEnumerator PlayWords(Camera cam, float lerpSpeed, float timeBetweenWords, string[] words, float delay) {

        yield return new WaitForSeconds(delay);

        int wordCount = 0;
        busy = true;
        instance.canvas.worldCamera = cam;

        
        while (wordCount < words.Length) {
            GameObject word = Instantiate(textPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            word.transform.SetParent(canvas.transform, false);
            word.GetComponent<TextMeshProUGUI>().text = words[wordCount];
            word.GetComponent<Temp_Text>().lerpSpeed = lerpSpeed;
            wordCount++;
            inProg = true;
            yield return new WaitUntil(checkInProg);
            yield return new WaitForSeconds(timeBetweenWords);
        }
        busy = false;
    }

    public bool checkInProg() {
        if (inProg)
        {
            return false;
        }
        else {
            return true;
        }
    }
}
