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
        //SceneJustLoaded = false;
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
        yield return new WaitForSeconds(2.5f);
        while (true)
        {
            //if (!SceneJustLoaded)
            //{
            //    SceneJustLoaded = true;
                
            //}

            if (Input.GetAxis(inputAxis1) < -0.8f && Input.GetAxis(inputAxis2) < -0.8f || Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(sceneToLoad);
            }

            yield return new WaitForSeconds(0.01f);
        }
    }
}
