using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MilkSceneChanger : MonoBehaviour
{
    public string sceneToLoad;
    public string inputAxis1 = "Milk1_Vertical";
    public string inputAxis2 = "Milk2_Vertical";
    private bool SceneJustLoaded = false;

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    //void Update()
    //{
    //    if (Input.GetAxis(inputAxis1) < -0.8f || Input.GetAxis(inputAxis2) < -0.8f || Input.GetKeyDown(KeyCode.Space))
    //    {
    //        SceneManager.LoadScene(sceneToLoad);
    //    }
    //}

    IEnumerator LoadScene()
    {
        while (true)
        {
            if (!SceneJustLoaded)
            {
                SceneJustLoaded = true;
                yield return new WaitForSeconds(1f);
            }

            if (Input.GetAxis(inputAxis1) < -0.8f || Input.GetAxis(inputAxis2) < -0.8f || Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(sceneToLoad);
            }

            yield return new WaitForSeconds(0.01f);
        }
    }
}
