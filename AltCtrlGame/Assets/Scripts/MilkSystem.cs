using System;
using System.Collections;
using UnityEngine;

public class MilkSystem : MonoBehaviour
{
    public float delayTimer;

    public int milkSpawnAmount = 4;
    public MilkSpawner milkSpawner;

    private bool p1Clicked;
    private bool p2Clicked;
    private int player1PreviousButton = 1;
    private float player1timerLeft;
    private float player1timerRight;
    private int player2PreviousButton = 1;
    private float player2timerLeft;
    private float player2timerRight;
    [SerializeField] public TeamInfo team1TeamInfo;
    [SerializeField] public TeamInfo team2TeamInfo;

    public AudioManager AM;

    private void Start()
    {
        ScoreManager.RegisterTeam(team1TeamInfo.teamTag, 0);
        ScoreManager.RegisterTeam(team2TeamInfo.teamTag, 1);

        StartCoroutine(MilkClickedP1());
        StartCoroutine(MilkClickedP2());
    }

    private IEnumerator MilkClickedP1()
    {
        while (true)
        {
            float waitTime;

            if (p1Clicked)
                waitTime = delayTimer;
            else
                waitTime = 0;


            yield return new WaitForSeconds(waitTime);
            p1Clicked = false;
            if (Input.GetAxis("Milk1") > 0 && player1PreviousButton == 2 && 
                Game_Manager.GameIsActive)
            {
                milkSpawner.SpawnBurst(
                    team1TeamInfo.udderRight,
                    team1TeamInfo.teamTag,
                    milkSpawnAmount
                );

                team1TeamInfo.Udder.GetComponent<Animator>().Play("right udder pull");
              
                ;
                

                ScoreManager.UpdateScoreData(team1TeamInfo.teamTag, ScoreType.milkProduced, milkSpawnAmount);

                p1Clicked = true;
                player1PreviousButton = 1;
            }

            if (Input.GetAxis("Milk1") < 0  && player1PreviousButton == 1 && p1Clicked == false &&
                Game_Manager.GameIsActive)
            {
                milkSpawner.SpawnBurst(
                    team1TeamInfo.udderLeft,
                    team1TeamInfo.teamTag,
                    milkSpawnAmount
                );
                
                team1TeamInfo.Udder.GetComponent<Animator>().Play("left udder pull");

                ScoreManager.UpdateScoreData(team1TeamInfo.teamTag, ScoreType.milkProduced, milkSpawnAmount);


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
                waitTime = delayTimer;
            else
                waitTime = 0;

            yield return new WaitForSeconds(waitTime);
            p2Clicked = false;
            if (Input.GetButtonDown("Milk2_Right") && player2PreviousButton == 2 && 
                Game_Manager.GameIsActive)
            {
                milkSpawner.SpawnBurst(
                    team2TeamInfo.udderRight,
                    team2TeamInfo.teamTag,
                    milkSpawnAmount
                );
                
                team2TeamInfo.Udder.GetComponent<Animator>().Play("right udder pull");

                ScoreManager.UpdateScoreData(team2TeamInfo.teamTag, ScoreType.milkProduced, milkSpawnAmount);

                p2Clicked = true;
                player2PreviousButton = 1;
            }

            if (Input.GetButtonDown("Milk2_Left") && player2PreviousButton == 1 && p2Clicked == false &&
                Game_Manager.GameIsActive)
            {
                milkSpawner.SpawnBurst(
                    team2TeamInfo.udderLeft,
                    team2TeamInfo.teamTag,
                    milkSpawnAmount
                );
                
                team2TeamInfo.Udder.GetComponent<Animator>().Play("left udder pull");

                ScoreManager.UpdateScoreData(team2TeamInfo.teamTag, ScoreType.milkProduced, milkSpawnAmount);

                p2Clicked = true;
                player2PreviousButton = 2;
            }
        }
    }

    [Serializable]
    public struct TeamInfo
    {
        public Transform udderLeft;
        public Transform udderRight;
        public string teamTag;
        public GameObject Udder;
    }
}