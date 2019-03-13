using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSystem : MonoBehaviour
{
    public int p1Score = 0;
    public int p2Score = 0;
    public float delayTimer;
    private float player1timerRight;
    private float player1timerLeft;
    private float player2timerRight;
    private float player2timerLeft;

    private bool p1Clicked;
    private bool p2Clicked;
    int player1PreviousButton = 1;
    int player2PreviousButton = 1;



    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MilkClickedP1());
        StartCoroutine(MilkClickedP2());
        
        /*player1timerRight = delayTimer;
        player1timerLeft = delayTimer;
        player2timerRight = delayTimer;
        player2timerLeft = delayTimer;*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator MilkClickedP1()
    {
        while (true)
        {


            float waitTime;
            
            if (p1Clicked)
            {
                waitTime = delayTimer;
            }
            else
            {
                waitTime = 0;
            }
            

            yield return new WaitForSeconds(waitTime);
            p1Clicked = false;
            if (Input.GetButtonDown("Milk1Right") && player1PreviousButton == 2)
            {
                p1Score++;                //Replace with milk added to Bucket
                p1Clicked = true;
                player1PreviousButton = 1;
            }

            if (Input.GetButtonDown("Milk1_Left")&& player1PreviousButton == 1 && p1Clicked == false)
            {
                p1Score++;                //Replace with milk added to Bucket
                p1Clicked = true;
                player1PreviousButton = 2;
            }


        }
    }
    private IEnumerator MilkClickedP2()
    {
        while (true)
        {


            float waitTime;
            
            if (p2Clicked)
            {
                waitTime = delayTimer;
            }
            else
            {
                waitTime = 0;
            }

            yield return new WaitForSeconds(waitTime);
            p2Clicked = false;
            if (Input.GetButtonDown("Milk2_Right") && player2PreviousButton == 2)
            {
                p2Score++;                //Replace with milk added to Bucket
                p2Clicked = true;
                player2PreviousButton = 1;
            }

            if (Input.GetButtonDown("Milk2_Left")&& player2PreviousButton == 1 && p2Clicked == false)
            {
                p2Score++;                //Replace with milk added to Bucket
                p2Clicked = true;
                player2PreviousButton = 2;
            }


        }
        

        
    }
}
